create sequence PACJENCI_SEQ
/

create sequence LEKARZE_SEQ
/

create sequence FARMACEUCI_SEQ
/

create sequence RECEPTY_SEQ
    nocache
/

create sequence ASORTYMENT_SEQ
    nocache
/

create table MIASTA
(
    ID_MIASTA    NUMBER       not null
        primary key,
    NAZWA_MIASTA VARCHAR2(50) not null
)
/

create table APTEKI
(
    ID_APTEKI    NUMBER       not null
        primary key,
    NAZWA_APTEKI VARCHAR2(50) not null,
    ULICA        VARCHAR2(50) not null,
    NUMER        VARCHAR2(50) not null,
    ID_MIASTA    NUMBER
        constraint FK_APTEKI_MIASTA
            references MIASTA
)
/

create table SPECJALIZACJE
(
    ID_SPECJALIZACJI    NUMBER       not null
        primary key,
    NAZWA_SPECJALIZACJI VARCHAR2(50) not null
)
/

create table LEKI
(
    ID_LEKU          NUMBER       not null
        primary key,
    NAZWA_LEKU       VARCHAR2(50) not null,
    OPIS             CLOB         not null,
    ID_SPECJALIZACJI NUMBER
        constraint FK_LEKI_SPECJALIZACJI
            references SPECJALIZACJE
)
/

create table CHOROBY
(
    ID_CHOROBY    NUMBER       not null
        primary key,
    NAZWA_CHOROBY VARCHAR2(50) not null,
    OBJAWY        CLOB         not null,
    OPIS          CLOB         not null
)
/

create table UZYTKOWNICY
(
    ID          NUMBER        not null
        primary key,
    LOGIN       VARCHAR2(50)  not null
        unique,
    HASLO       VARCHAR2(255) not null,
    UPRAWNIENIA VARCHAR2(12)  not null
        check (Uprawnienia IN ('Pacjent', 'Lekarz', 'Farmaceuta'))
)
/

create trigger ASSIGNPERMISSIONS
    before insert
    on UZYTKOWNICY
    for each row
BEGIN
    IF :NEW.Uprawnienia IS NULL THEN
        IF :NEW.Login LIKE 'lek%' THEN
            :NEW.Uprawnienia := 'Lekarz';
        ELSIF :NEW.Login LIKE 'pac%' THEN
            :NEW.Uprawnienia := 'Pacjent';
        ELSIF :NEW.Login LIKE 'far%' THEN
            :NEW.Uprawnienia := 'Farmaceuta';
        ELSE
            :NEW.Uprawnienia := 'Inne';
        END IF;
    END IF;
END;
/

create table PACJENCI
(
    ID             NUMBER       not null
        primary key,
    ID_UZYTKOWNIKA NUMBER
        constraint FK_PACJENCI_UZYTKOWNICY
            references UZYTKOWNICY,
    IMIE           VARCHAR2(50) not null,
    NAZWISKO       VARCHAR2(50) not null,
    PESEL          VARCHAR2(11) not null
        constraint UQ_PACJENCI_PESEL
            unique,
    DATA_URODZENIA DATE,
    PLEC           CHAR
)
/

create table LEKARZE
(
    ID               NUMBER       not null
        primary key,
    ID_UZYTKOWNIKA   NUMBER
        constraint FK_LEKARZE_UZYTKOWNICY
            references UZYTKOWNICY,
    IMIE             VARCHAR2(50) not null,
    NAZWISKO         VARCHAR2(50) not null,
    ID_SPECJALIZACJI NUMBER
        constraint FK_LEKARZE_SPECJALIZACJA
            references SPECJALIZACJE,
    NUMER_PWZ        VARCHAR2(7)  not null,
    ID_MIASTA        NUMBER
        constraint FK_LEKARZE_MIASTA
            references MIASTA,
    DATA_URODZENIA   DATE,
    PLEC             CHAR
)
/

create table RECEPTY
(
    ID_RECEPTY       NUMBER       not null
        primary key,
    ID_PACJENTA      NUMBER
        constraint FK_RECEPTY_PACJENTA
            references PACJENCI,
    ID_LEKARZA       NUMBER
        constraint FK_RECEPTY_LEKARZA
            references LEKARZE,
    DATA_WYSTAWIENIA DATE         not null,
    KOD_RECEPTY      VARCHAR2(6)  not null,
    STATUS           VARCHAR2(20) not null,
    DATA_WYGASNIECIA DATE
)
/

create table RECEPTY_LEKI
(
    ID_RECEPTY  NUMBER not null
        constraint FK_RECEPTY_LEKI_RECEPTY
            references RECEPTY,
    ID_LEKU     NUMBER not null
        constraint FK_RECEPTY_LEKI_LEKI
            references LEKI,
    ILOSC_SZTUK NUMBER not null,
    primary key (ID_RECEPTY, ID_LEKU)
)
/

create trigger TRIGGER_DODAJ_LEK
    after insert
    on RECEPTY_LEKI
    for each row
BEGIN
  UPDATE ASORTYMENT
  SET ILOSC_DOSTEPNYCH_SZTUK = ILOSC_DOSTEPNYCH_SZTUK + :NEW.ILOSC_SZTUK
  WHERE ID_LEKU = :NEW.ID_LEKU;
END;
/

create trigger TRIGGER_ODJEM_LEK
    after delete
    on RECEPTY_LEKI
    for each row
BEGIN
  UPDATE ASORTYMENT
  SET ILOSC_DOSTEPNYCH_SZTUK = ILOSC_DOSTEPNYCH_SZTUK - :OLD.ILOSC_SZTUK
  WHERE ID_LEKU = :OLD.ID_LEKU;
END;
/

create table FARMACEUCI
(
    ID             NUMBER       not null
        primary key,
    ID_UZYTKOWNIKA NUMBER
        constraint FK_FARMACEUCI_UZYTKOWNICY
            references UZYTKOWNICY,
    IMIE           VARCHAR2(50) not null,
    NAZWISKO       VARCHAR2(50) not null,
    ID_APTEKI      NUMBER
        constraint FK_FARMACEUCI_APTEKI
            references APTEKI,
    DATA_URODZENIA DATE,
    PLEC           CHAR
)
/

create table ASORTYMENT
(
    ID_ASORTYMENTU         NUMBER not null
        primary key,
    ID_APTEKI              NUMBER
        constraint FK_ASORTYMENT_APTEKI
            references APTEKI,
    ID_LEKU                NUMBER
        constraint FK_ASORTYMENT_LEKI
            references LEKI,
    CENA                   NUMBER not null,
    ILOSC_DOSTEPNYCH_SZTUK NUMBER not null
)
/

create table ASORTYMENT_LEKI
(
    ID_ASORTYMENTU NUMBER not null
        constraint FK_ASORTYMENT_LEKI_ASORTYMENT
            references ASORTYMENT,
    ID_LEKU        NUMBER not null
        constraint FK_ASORTYMENT_LEKI_LEKI
            references LEKI,
    primary key (ID_ASORTYMENTU, ID_LEKU)
)
/

create table CHOROBY_LEKI
(
    ID_CHOROBY_LEKU NUMBER not null
        primary key,
    ID_LEKU         NUMBER
        constraint FK_CHOROBY_LEKI_LEKI
            references LEKI,
    ID_CHOROBY      NUMBER
        constraint FK_CHOROBY_LEKI_CHOROBY
            references CHOROBY
)
/

create PACKAGE USER_PKG AS
    PROCEDURE ADDPACJENT(
        p_login IN VARCHAR2,
        p_haslo IN VARCHAR2,
        p_imie IN VARCHAR2,
        p_nazwisko IN VARCHAR2,
        p_pesel IN VARCHAR2,
        p_plec IN CHAR,
        p_data_urodzenia IN DATE,
        p_error_message OUT VARCHAR2
    );

    PROCEDURE ADDLEKARZ(
        p_login IN VARCHAR2,
        p_haslo IN VARCHAR2,
        p_imie IN VARCHAR2,
        p_nazwisko IN VARCHAR2,
        p_plec IN CHAR,
        p_data_urodzenia IN DATE,
        p_specjalizacja IN VARCHAR2,
        p_numer_pwz IN VARCHAR2,
        p_miasto IN VARCHAR2,
        p_error_message OUT VARCHAR2
    );

    PROCEDURE ADDFARMACEUTA(
        p_login IN VARCHAR2,
        p_haslo IN VARCHAR2,
        p_imie IN VARCHAR2,
        p_nazwisko IN VARCHAR2,
        p_plec IN CHAR,
        p_data_urodzenia IN DATE,
        p_id_apteki IN NUMBER,
        p_error_message OUT VARCHAR2
    );

    PROCEDURE GET_LEKARZE(
        p_miasto IN VARCHAR2,
        p_specjalizacja IN VARCHAR2,
        cur OUT SYS_REFCURSOR
    );
END USER_PKG;
/

create PACKAGE BODY USER_PKG AS
    PROCEDURE ADDPACJENT(
        p_login IN VARCHAR2,
        p_haslo IN VARCHAR2,
        p_imie IN VARCHAR2,
        p_nazwisko IN VARCHAR2,
        p_pesel IN VARCHAR2,
        p_plec IN CHAR,
        p_data_urodzenia IN DATE,
        p_error_message OUT VARCHAR2
    ) AS
        v_id_logowanie NUMBER;
        v_pacjent_id NUMBER;
        v_count NUMBER;
    BEGIN
        -- Sprawdzenie, czy PESEL już istnieje
        SELECT COUNT(*)
        INTO v_count
        FROM Pacjenci
        WHERE PESEL = p_pesel;

        IF v_count > 0 THEN
            p_error_message := 'PESEL already exists.';
            RETURN;
        END IF;

        -- Sprawdzenie, czy login już istnieje
        SELECT COUNT(*)
        INTO v_count
        FROM Uzytkownicy
        WHERE Login = p_login;

        IF v_count > 0 THEN
            p_error_message := 'Login already exists.';
            RETURN;
        END IF;

        -- Uzyskanie następnej wartości ID dla użytkownika
        SELECT NVL(MAX(ID), 0) + 1 INTO v_id_logowanie FROM Uzytkownicy;

        -- Dodanie użytkownika do tabeli Uzytkownicy
        INSERT INTO Uzytkownicy (ID, Login, Haslo, Uprawnienia)
        VALUES (v_id_logowanie, p_login, p_haslo, 'Pacjent')
        RETURNING ID INTO v_id_logowanie;

        -- Uzyskanie następnej wartości ID dla pacjenta
        SELECT Pacjenci_SEQ.NEXTVAL INTO v_pacjent_id FROM dual;

        -- Dodanie użytkownika do tabeli Pacjenci
        INSERT INTO Pacjenci (ID, Imie, Nazwisko, PESEL, Data_urodzenia, Plec, ID_Uzytkownika)
        VALUES (v_pacjent_id, p_imie, p_nazwisko, p_pesel, p_data_urodzenia, p_plec, v_id_logowanie);

        -- Ustawienie komunikatu sukcesu
        p_error_message := 'User added successfully.';
    EXCEPTION
        WHEN OTHERS THEN
            p_error_message := SQLERRM;
    END ADDPACJENT;

    PROCEDURE ADDLEKARZ(
        p_login IN VARCHAR2,
        p_haslo IN VARCHAR2,
        p_imie IN VARCHAR2,
        p_nazwisko IN VARCHAR2,
        p_plec IN CHAR,
        p_data_urodzenia IN DATE,
        p_specjalizacja IN VARCHAR2,
        p_numer_pwz IN VARCHAR2,
        p_miasto IN VARCHAR2,
        p_error_message OUT VARCHAR2
    ) AS
        v_id_logowanie NUMBER;
        v_lekarz_id NUMBER;
        v_id_specjalizacji NUMBER;
        v_id_miasta NUMBER;
        v_count NUMBER;
    BEGIN
        -- Sprawdzenie, czy login już istnieje
        SELECT COUNT(*)
        INTO v_count
        FROM Uzytkownicy
        WHERE Login = p_login;

        IF v_count > 0 THEN
            p_error_message := 'Login already exists.';
            RETURN;
        END IF;

        -- Sprawdzenie, czy specjalizacja istnieje
        SELECT ID_Specjalizacji
        INTO v_id_specjalizacji
        FROM Specjalizacje
        WHERE nazwa_specjalizacji = p_specjalizacja;

        -- Sprawdzenie, czy miasto istnieje
        SELECT ID_Miasta
        INTO v_id_miasta
        FROM Miasta
        WHERE Nazwa_miasta = p_miasto;

        -- Uzyskanie następnej wartości ID dla użytkownika
        SELECT NVL(MAX(ID), 0) + 1 INTO v_id_logowanie FROM Uzytkownicy;

        -- Dodanie użytkownika do tabeli Uzytkownicy
        INSERT INTO Uzytkownicy (ID, Login, Haslo, Uprawnienia)
        VALUES (v_id_logowanie, p_login, p_haslo, 'Lekarz')
        RETURNING ID INTO v_id_logowanie;

        -- Uzyskanie następnej wartości ID dla lekarza
        SELECT Lekarze_SEQ.NEXTVAL INTO v_lekarz_id FROM dual;

        -- Dodanie użytkownika do tabeli Lekarze
        INSERT INTO Lekarze (ID, Imie, Nazwisko, ID_Specjalizacji, Numer_PWZ, ID_Miasta, Data_urodzenia, Plec, ID_Uzytkownika)
        VALUES (v_lekarz_id, p_imie, p_nazwisko, v_id_specjalizacji, p_numer_pwz, v_id_miasta, p_data_urodzenia, p_plec, v_id_logowanie);

        -- Ustawienie komunikatu sukcesu
        p_error_message := 'User added successfully.';
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            p_error_message := 'Invalid specialization or city.';
        WHEN OTHERS THEN
            p_error_message := SQLERRM;
    END ADDLEKARZ;

    PROCEDURE ADDFARMACEUTA(
        p_login IN VARCHAR2,
        p_haslo IN VARCHAR2,
        p_imie IN VARCHAR2,
        p_nazwisko IN VARCHAR2,
        p_plec IN CHAR,
        p_data_urodzenia IN DATE,
        p_id_apteki IN NUMBER,
        p_error_message OUT VARCHAR2
    ) AS
        v_id_logowanie NUMBER;
        v_farmaceuta_id NUMBER;
        v_count NUMBER;
    BEGIN
        -- Sprawdzenie, czy login już istnieje
        SELECT COUNT(*)
        INTO v_count
        FROM Uzytkownicy
        WHERE Login = p_login;

        IF v_count > 0 THEN
            p_error_message := 'Login already exists.';
            RETURN;
        END IF;

        -- Uzyskanie następnej wartości ID dla użytkownika
        SELECT NVL(MAX(ID), 0) + 1 INTO v_id_logowanie FROM Uzytkownicy;

        -- Dodanie użytkownika do tabeli Uzytkownicy
        INSERT INTO Uzytkownicy (ID, Login, Haslo, Uprawnienia)
        VALUES (v_id_logowanie, p_login, p_haslo, 'Farmaceuta')
        RETURNING ID INTO v_id_logowanie;

        -- Uzyskanie następnej wartości ID dla farmaceuty
        SELECT Farmaceuci_SEQ.NEXTVAL INTO v_farmaceuta_id FROM dual;

        -- Dodanie użytkownika do tabeli Farmaceuci
        INSERT INTO Farmaceuci (ID, Imie, Nazwisko, ID_Apteki, Data_urodzenia, Plec, ID_Uzytkownika)
        VALUES (v_farmaceuta_id, p_imie, p_nazwisko, p_id_apteki, p_data_urodzenia, p_plec, v_id_logowanie);

        -- Ustawienie komunikatu sukcesu
        p_error_message := 'User added successfully.';
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            p_error_message := 'Invalid pharmacy.';
        WHEN OTHERS THEN
            p_error_message := SQLERRM;
    END ADDFARMACEUTA;

    PROCEDURE GET_LEKARZE(
        p_miasto IN VARCHAR2,
        p_specjalizacja IN VARCHAR2,
        cur OUT SYS_REFCURSOR
    ) AS
    BEGIN
        OPEN cur FOR
        SELECT l.IMIE, l.NAZWISKO, s.NAZWA_SPECJALIZACJI, m.NAZWA_MIASTA
        FROM LEKARZE l
        JOIN SPECJALIZACJE s ON l.ID_SPECJALIZACJI = s.ID_SPECJALIZACJI
        JOIN MIASTA m ON l.ID_MIASTA = m.ID_MIASTA
        WHERE (p_miasto IS NULL OR m.NAZWA_MIASTA = p_miasto)
        AND (p_specjalizacja IS NULL OR s.NAZWA_SPECJALIZACJI = p_specjalizacja);
    END GET_LEKARZE;

END USER_PKG;
/

create PACKAGE RECEPT_PKG AS
    PROCEDURE ADD_RECEIPTA(
        P_ID_PACJENTA IN NUMBER,
        P_ID_LEKARZA IN NUMBER,
        P_DATA_WYSTAWIENIA IN DATE,
        P_KOD_RECEIPTY OUT VARCHAR2,
        P_ID_RECEIPTY OUT NUMBER
    );

    PROCEDURE ADD_RECEIPTA_LEKI(
        P_ID_RECEIPTY IN NUMBER,
        P_ID_LEKU IN NUMBER,
        P_ILOSC_SZTUK IN NUMBER
    );

    PROCEDURE GET_RECEIPTA_LEKI_DETAILS(
        p_recepta_id IN NUMBER,
        p_apteka_id IN NUMBER,
        cur OUT SYS_REFCURSOR
    );

    PROCEDURE ZATWIERDZ_RECEPTE(
        p_recepta_id IN NUMBER
    );

    PROCEDURE UPDATE_ASORTYMENT_PO_ZATWIERDZENIU(
        p_ilosc_sztuk IN NUMBER,
        p_lek_nazwa IN VARCHAR2,
        p_apteka_id IN NUMBER
    );

    PROCEDURE USUN_LEK(
        p_recepta_id IN NUMBER,
        p_lek_nazwa IN VARCHAR2,
        p_apteka_id IN NUMBER
    );

    FUNCTION GENERATE_UNIQUE_KOD_RECEIPTY RETURN VARCHAR2;
END RECEPT_PKG;
/

create PACKAGE BODY RECEPT_PKG AS
    PROCEDURE ADD_RECEIPTA(
        P_ID_PACJENTA IN NUMBER,
        P_ID_LEKARZA IN NUMBER,
        P_DATA_WYSTAWIENIA IN DATE,
        P_KOD_RECEIPTY OUT VARCHAR2,
        P_ID_RECEIPTY OUT NUMBER
    ) AS
        v_count NUMBER;
        v_data_wygasniecia DATE;
    BEGIN
        -- Sprawdzenie, czy ID pacjenta jest prawidłowe
        SELECT COUNT(1) INTO v_count FROM Pacjenci WHERE ID = P_ID_PACJENTA;
        IF v_count = 0 THEN
            RAISE_APPLICATION_ERROR(-20001, 'Invalid Pacjent ID');
        END IF;

        -- Sprawdzenie, czy ID lekarza jest prawidłowe
        SELECT COUNT(1) INTO v_count FROM Lekarze WHERE ID = P_ID_LEKARZA;
        IF v_count = 0 THEN
            RAISE_APPLICATION_ERROR(-20002, 'Invalid Lekarz ID');
        END IF;

        -- Generowanie unikalnego kodu recepty
        P_KOD_RECEIPTY := GENERATE_UNIQUE_KOD_RECEIPTY;

        -- Pobieranie nowego ID z sekwencji
        SELECT RECEPTY_SEQ.NEXTVAL INTO P_ID_RECEIPTY FROM DUAL;

        -- Obliczanie daty wygaśnięcia
        v_data_wygasniecia := ADD_MONTHS(P_DATA_WYSTAWIENIA, 1);

        -- Wstawianie nowej recepty
        INSERT INTO RECEPTY (ID_RECEPTY, ID_PACJENTA, ID_LEKARZA, DATA_WYSTAWIENIA, KOD_RECEPTY, STATUS, DATA_WYGASNIECIA)
        VALUES (P_ID_RECEIPTY, P_ID_PACJENTA, P_ID_LEKARZA, P_DATA_WYSTAWIENIA, P_KOD_RECEIPTY, 'Do zrealizowania', v_data_wygasniecia);

        COMMIT;
    END ADD_RECEIPTA;

    PROCEDURE ADD_RECEIPTA_LEKI(
        P_ID_RECEIPTY IN NUMBER,
        P_ID_LEKU IN NUMBER,
        P_ILOSC_SZTUK IN NUMBER
    ) AS
    BEGIN
        INSERT INTO RECEPTY_LEKI (ID_RECEPTY, ID_LEKU, ILOSC_SZTUK)
        VALUES (P_ID_RECEIPTY, P_ID_LEKU, P_ILOSC_SZTUK);
    END ADD_RECEIPTA_LEKI;

    PROCEDURE GET_RECEIPTA_LEKI_DETAILS(
        p_recepta_id IN NUMBER,
        p_apteka_id IN NUMBER,
        cur OUT SYS_REFCURSOR
    ) AS
    BEGIN
        OPEN cur FOR
            SELECT
                L.NAZWA_LEKU,
                RL.ILOSC_SZTUK,
                CASE
                    WHEN A.ID_LEKU IS NOT NULL THEN 'Tak'
                    ELSE 'Nie'
                END AS DOSTEPNOSC,
                A.ILOSC_DOSTEPNYCH_SZTUK,
                A.CENA
            FROM
                RECEPTY_LEKI RL
                JOIN LEKI L ON RL.ID_LEKU = L.ID_LEKU
                LEFT JOIN ASORTYMENT A ON A.ID_LEKU = L.ID_LEKU AND A.ID_APTEKI = p_apteka_id
            WHERE
                RL.ID_RECEPTY = p_recepta_id;
    END GET_RECEIPTA_LEKI_DETAILS;

    PROCEDURE ZATWIERDZ_RECEPTE(
        p_recepta_id IN NUMBER
    ) AS
    BEGIN
        UPDATE RECEPTY
        SET STATUS = 'Zrealizowana', DATA_WYGASNIECIA = SYSDATE + 1
        WHERE ID_RECEPTY = p_recepta_id;
        COMMIT;
    END ZATWIERDZ_RECEPTE;

    PROCEDURE UPDATE_ASORTYMENT_PO_ZATWIERDZENIU(
        p_ilosc_sztuk IN NUMBER,
        p_lek_nazwa IN VARCHAR2,
        p_apteka_id IN NUMBER
    ) AS
    BEGIN
        UPDATE ASORTYMENT
        SET ILOSC_DOSTEPNYCH_SZTUK = ILOSC_DOSTEPNYCH_SZTUK - p_ilosc_sztuk
        WHERE ID_LEKU = (SELECT ID_LEKU FROM LEKI WHERE NAZWA_LEKU = p_lek_nazwa)
        AND ID_APTEKI = p_apteka_id;
        COMMIT;
    END UPDATE_ASORTYMENT_PO_ZATWIERDZENIU;

    PROCEDURE USUN_LEK(
        p_recepta_id IN NUMBER,
        p_lek_nazwa IN VARCHAR2,
        p_apteka_id IN NUMBER
    ) AS
        v_ilosc_sztuk NUMBER;
    BEGIN
        -- Pobieranie ilości sztuk leku przed usunięciem
        SELECT ILOSC_SZTUK INTO v_ilosc_sztuk
        FROM RECEPTY_LEKI
        WHERE ID_RECEPTY = p_recepta_id
        AND ID_LEKU = (SELECT ID_LEKU FROM LEKI WHERE NAZWA_LEKU = p_lek_nazwa)
        FOR UPDATE;

        -- Usuwanie leku z recepty
        DELETE FROM RECEPTY_LEKI
        WHERE ID_RECEPTY = p_recepta_id
        AND ID_LEKU = (SELECT ID_LEKU FROM LEKI WHERE NAZWA_LEKU = p_lek_nazwa);

        -- Aktualizacja asortymentu
        UPDATE ASORTYMENT
        SET ILOSC_DOSTEPNYCH_SZTUK = ILOSC_DOSTEPNYCH_SZTUK - v_ilosc_sztuk
        WHERE ID_LEKU = (SELECT ID_LEKU FROM LEKI WHERE NAZWA_LEKU = p_lek_nazwa)
        AND ID_APTEKI = p_apteka_id;

        COMMIT;
    END USUN_LEK;

    FUNCTION GENERATE_UNIQUE_KOD_RECEIPTY RETURN VARCHAR2 IS
        v_kod_receipty VARCHAR2(6);
        v_count NUMBER;
    BEGIN
        LOOP
            -- Generowanie losowego 6-cyfrowego kodu
            v_kod_receipty := LPAD(TO_CHAR(FLOOR(DBMS_RANDOM.VALUE(0, 999999))), 6, '0');

            -- Sprawdzenie, czy kod jest unikalny
            SELECT COUNT(*)
            INTO v_count
            FROM RECEPTY
            WHERE KOD_RECEPTY = v_kod_receipty;

            -- Jeśli kod jest unikalny, wyjście z pętli
            EXIT WHEN v_count = 0;
        END LOOP;

        RETURN v_kod_receipty;
    END GENERATE_UNIQUE_KOD_RECEIPTY;

END RECEPT_PKG;
/

create PACKAGE utility_pkg AS
    FUNCTION GenerateUniqueKodReceipty RETURN VARCHAR2;

    FUNCTION ValidatePESEL(p_pesel IN VARCHAR2) RETURN NUMBER;

    PROCEDURE GetLekarze(
        p_miasto IN VARCHAR2,
        p_specjalizacja IN VARCHAR2,
        cur OUT SYS_REFCURSOR
    );

    PROCEDURE AddLekToAsortyment(
        p_id_apteki IN NUMBER,
        p_id_leku IN NUMBER,
        p_ilosc_sztuk IN NUMBER,
        p_cena IN NUMBER
    );
END utility_pkg;
/

create PACKAGE BODY utility_pkg AS

    FUNCTION GenerateUniqueKodReceipty RETURN VARCHAR2 IS
        v_kod_receipty VARCHAR2(6);
        v_count NUMBER;
    BEGIN
        LOOP
            -- Generowanie losowego 6-cyfrowego kodu
            v_kod_receipty := LPAD(TO_CHAR(FLOOR(DBMS_RANDOM.VALUE(0, 999999))), 6, '0');

            -- Sprawdzenie, czy kod jest unikalny
            SELECT COUNT(*)
            INTO v_count
            FROM RECEPTY
            WHERE KOD_RECEPTY = v_kod_receipty;

            -- Jeśli kod jest unikalny, wyjście z pętli
            EXIT WHEN v_count = 0;
        END LOOP;

        RETURN v_kod_receipty;
    END GenerateUniqueKodReceipty;

    FUNCTION ValidatePESEL(p_pesel IN VARCHAR2) RETURN NUMBER IS
        v_length NUMBER;
    BEGIN
        -- Sprawdzenie długości PESEL
        v_length := LENGTH(p_pesel);

        IF v_length != 11 OR NOT REGEXP_LIKE(p_pesel, '^\d{11}$') THEN
            RETURN 0; -- Niepoprawny PESEL
        ELSE
            RETURN 1; -- Poprawny PESEL
        END IF;
    END ValidatePESEL;

    PROCEDURE GetLekarze(
        p_miasto IN VARCHAR2,
        p_specjalizacja IN VARCHAR2,
        cur OUT SYS_REFCURSOR
    ) AS
    BEGIN
        OPEN cur FOR
        SELECT l.IMIE, l.NAZWISKO, s.NAZWA_SPECJALIZACJI, m.NAZWA_MIASTA
        FROM LEKARZE l
        JOIN SPECJALIZACJE s ON l.ID_SPECJALIZACJI = s.ID_SPECJALIZACJI
        JOIN MIASTA m ON l.ID_MIASTA = m.ID_MIASTA
        WHERE (p_miasto IS NULL OR m.NAZWA_MIASTA = p_miasto)
        AND (p_specjalizacja IS NULL OR s.NAZWA_SPECJALIZACJI = p_specjalizacja);
    END;

    PROCEDURE AddLekToAsortyment(
        p_id_apteki IN NUMBER,
        p_id_leku IN NUMBER,
        p_ilosc_sztuk IN NUMBER,
        p_cena IN NUMBER
    ) AS
    BEGIN
        INSERT INTO Asortyment (ID_Asortymentu, ID_Apteki, ID_Leku, Cena, Ilosc_dostepnych_sztuk)
        VALUES (Asortyment_SEQ.NEXTVAL, p_id_apteki, p_id_leku, p_cena, p_ilosc_sztuk);
        COMMIT;
    END;

END utility_pkg;
/

create PACKAGE asortyment_pkg AS
    PROCEDURE ADD_LEK_TO_ASORTYMENT(
        p_id_apteki IN NUMBER,
        p_id_leku IN NUMBER,
        p_ilosc_sztuk IN NUMBER,
        p_cena IN NUMBER
    );
END asortyment_pkg;
/

create PACKAGE BODY asortyment_pkg AS
    PROCEDURE ADD_LEK_TO_ASORTYMENT(
        p_id_apteki IN NUMBER,
        p_id_leku IN NUMBER,
        p_ilosc_sztuk IN NUMBER,
        p_cena IN NUMBER
    ) AS
    BEGIN
        INSERT INTO Asortyment (ID_Asortymentu, ID_Apteki, ID_Leku, Cena, Ilosc_dostepnych_sztuk)
        VALUES (Asortyment_SEQ.NEXTVAL, p_id_apteki, p_id_leku, p_cena, p_ilosc_sztuk);
        COMMIT;
    END ADD_LEK_TO_ASORTYMENT;
END asortyment_pkg;
/

create PROCEDURE AddPacjent(
    p_login IN VARCHAR2,
    p_haslo IN VARCHAR2,
    p_imie IN VARCHAR2,
    p_nazwisko IN VARCHAR2,
    p_pesel IN VARCHAR2,
    p_plec IN CHAR,
    p_data_urodzenia IN DATE,
    p_error_message OUT VARCHAR2
) AS
    v_id_logowanie NUMBER;
    v_pacjent_id NUMBER;
    v_count NUMBER;
BEGIN
    -- Sprawdzenie, czy PESEL już istnieje
    SELECT COUNT(*)
    INTO v_count
    FROM Pacjenci
    WHERE PESEL = p_pesel;

    IF v_count > 0 THEN
        p_error_message := 'PESEL already exists.';
        RETURN;
    END IF;

    -- Sprawdzenie, czy login już istnieje
    SELECT COUNT(*)
    INTO v_count
    FROM Uzytkownicy
    WHERE Login = p_login;

    IF v_count > 0 THEN
        p_error_message := 'Login already exists.';
        RETURN;
    END IF;

    -- Uzyskanie następnej wartości ID dla użytkownika
    SELECT NVL(MAX(ID), 0) + 1 INTO v_id_logowanie FROM Uzytkownicy;

    -- Dodanie użytkownika do tabeli Uzytkownicy
    INSERT INTO Uzytkownicy (ID, Login, Haslo, Uprawnienia)
    VALUES (v_id_logowanie, p_login, p_haslo, 'Pacjent')
    RETURNING ID INTO v_id_logowanie;

    -- Uzyskanie następnej wartości ID dla pacjenta
    SELECT Pacjenci_SEQ.NEXTVAL INTO v_pacjent_id FROM dual;

    -- Dodanie użytkownika do tabeli Pacjenci
    INSERT INTO Pacjenci (ID, Imie, Nazwisko, PESEL, Data_urodzenia, Plec, ID_Uzytkownika)
    VALUES (v_pacjent_id, p_imie, p_nazwisko, p_pesel, p_data_urodzenia, p_plec, v_id_logowanie);

    -- Ustawienie komunikatu sukcesu
    p_error_message := 'User added successfully.';
EXCEPTION
    WHEN OTHERS THEN
        p_error_message := SQLERRM;
END AddPacjent;
/

create PROCEDURE AddLekarz(
    p_login IN VARCHAR2,
    p_haslo IN VARCHAR2,
    p_imie IN VARCHAR2,
    p_nazwisko IN VARCHAR2,
    p_plec IN CHAR,
    p_data_urodzenia IN DATE,
    p_specjalizacja IN VARCHAR2,
    p_numer_pwz IN VARCHAR2,
    p_miasto IN VARCHAR2,
    p_error_message OUT VARCHAR2
) AS
    v_id_logowanie NUMBER;
    v_lekarz_id NUMBER;
    v_id_specjalizacji NUMBER;
    v_id_miasta NUMBER;
    v_count NUMBER;
BEGIN
    -- Sprawdzenie, czy login już istnieje
    SELECT COUNT(*)
    INTO v_count
    FROM Uzytkownicy
    WHERE Login = p_login;

    IF v_count > 0 THEN
        p_error_message := 'Login already exists.';
        RETURN;
    END IF;

    -- Sprawdzenie, czy specjalizacja istnieje
    SELECT ID_Specjalizacji
    INTO v_id_specjalizacji
    FROM Specjalizacje
    WHERE nazwa_specjalizacji = p_specjalizacja;

    -- Sprawdzenie, czy miasto istnieje
    SELECT ID_Miasta
    INTO v_id_miasta
    FROM Miasta
    WHERE Nazwa_miasta = p_miasto;

    -- Uzyskanie następnej wartości ID dla użytkownika
    SELECT NVL(MAX(ID), 0) + 1 INTO v_id_logowanie FROM Uzytkownicy;

    -- Dodanie użytkownika do tabeli Uzytkownicy
    INSERT INTO Uzytkownicy (ID, Login, Haslo, Uprawnienia)
    VALUES (v_id_logowanie, p_login, p_haslo, 'Lekarz')
    RETURNING ID INTO v_id_logowanie;

    -- Uzyskanie następnej wartości ID dla lekarza
    SELECT Lekarze_SEQ.NEXTVAL INTO v_lekarz_id FROM dual;

    -- Dodanie użytkownika do tabeli Lekarze
    INSERT INTO Lekarze (ID, Imie, Nazwisko, ID_Specjalizacji, Numer_PWZ, ID_Miasta, Data_urodzenia, Plec, ID_Uzytkownika)
    VALUES (v_lekarz_id, p_imie, p_nazwisko, v_id_specjalizacji, p_numer_pwz, v_id_miasta, p_data_urodzenia, p_plec, v_id_logowanie);

    -- Ustawienie komunikatu sukcesu
    p_error_message := 'User added successfully.';
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_message := 'Invalid specialization or city.';
    WHEN OTHERS THEN
        p_error_message := SQLERRM;
END AddLekarz;
/

create PROCEDURE AddFarmaceuta(
    p_login IN VARCHAR2,
    p_haslo IN VARCHAR2,
    p_imie IN VARCHAR2,
    p_nazwisko IN VARCHAR2,
    p_plec IN CHAR,
    p_data_urodzenia IN DATE,
    p_apteka IN VARCHAR2,
    p_error_message OUT VARCHAR2
) AS
    v_id_logowanie NUMBER;
    v_farmaceuta_id NUMBER;
    v_id_apteki NUMBER;
    v_count NUMBER;
BEGIN
    -- Sprawdzenie, czy login już istnieje
    SELECT COUNT(*)
    INTO v_count
    FROM Uzytkownicy
    WHERE Login = p_login;

    IF v_count > 0 THEN
        p_error_message := 'Login already exists.';
        RETURN;
    END IF;

    -- Extract the components of the apteka string
    DECLARE
        v_nazwa_apteki VARCHAR2(50);
        v_miasto VARCHAR2(50);
        v_ulica VARCHAR2(50);
        v_numer VARCHAR2(50);
    BEGIN
        v_nazwa_apteki := SUBSTR(p_apteka, 1, INSTR(p_apteka, ',') - 1);
        v_miasto := SUBSTR(p_apteka, INSTR(p_apteka, ',') + 2, INSTR(p_apteka, ',', INSTR(p_apteka, ',') + 1) - INSTR(p_apteka, ',') - 2);
        v_ulica := SUBSTR(p_apteka, INSTR(p_apteka, ',', INSTR(p_apteka, ',') + 1) + 2, INSTR(p_apteka, ',', INSTR(p_apteka, ',', INSTR(p_apteka, ',') + 1) + 1) - INSTR(p_apteka, ',', INSTR(p_apteka, ',') + 1) - 2);
        v_numer := SUBSTR(p_apteka, INSTR(p_apteka, ',', INSTR(p_apteka, ',', INSTR(p_apteka, ',') + 1) + 1) + 2);

        -- Sprawdzenie, czy apteka istnieje
        SELECT ID_Apteki
        INTO v_id_apteki
        FROM Apteki
        WHERE Nazwa_apteki = v_nazwa_apteki AND Ulica = v_ulica AND Numer = v_numer AND ID_Miasta = (SELECT ID_Miasta FROM Miasta WHERE Nazwa_miasta = v_miasto);

        -- Uzyskanie następnej wartości ID dla użytkownika
        SELECT NVL(MAX(ID), 0) + 1 INTO v_id_logowanie FROM Uzytkownicy;

        -- Dodanie użytkownika do tabeli Uzytkownicy
        INSERT INTO Uzytkownicy (ID, Login, Haslo, Uprawnienia)
        VALUES (v_id_logowanie, p_login, p_haslo, 'Farmaceuta')
        RETURNING ID INTO v_id_logowanie;

        -- Uzyskanie następnej wartości ID dla farmaceuty
        SELECT Farmaceuci_SEQ.NEXTVAL INTO v_farmaceuta_id FROM dual;

        -- Dodanie użytkownika do tabeli Farmaceuci
        INSERT INTO Farmaceuci (ID, Imie, Nazwisko, ID_Apteki, Data_urodzenia, Plec, ID_Uzytkownika)
        VALUES (v_farmaceuta_id, p_imie, p_nazwisko, v_id_apteki, p_data_urodzenia, p_plec, v_id_logowanie);

        -- Ustawienie komunikatu sukcesu
        p_error_message := 'User added successfully.';
    END;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_message := 'Invalid pharmacy.';
    WHEN OTHERS THEN
        p_error_message := SQLERRM;
END AddFarmaceuta;
/

create FUNCTION ValidatePESEL(p_pesel IN VARCHAR2) RETURN NUMBER IS
    v_length NUMBER;
BEGIN
    -- Sprawdzenie długości PESEL
    v_length := LENGTH(p_pesel);

    IF v_length != 11 OR NOT REGEXP_LIKE(p_pesel, '^\d{11}$') THEN
        RETURN 0; -- Niepoprawny PESEL
    ELSE
        RETURN 1; -- Poprawny PESEL
    END IF;
END ValidatePESEL;
/

create PROCEDURE GetUserDetails (
    p_login IN VARCHAR2,
    p_imie OUT VARCHAR2,
    p_nazwisko OUT VARCHAR2,
    p_haslo OUT VARCHAR2,
    p_uprawnienia OUT VARCHAR2,
    p_pesel OUT VARCHAR2,
    p_data_urodzenia OUT DATE,
    p_plec OUT CHAR
) AS
BEGIN
    SELECT p.Imie, p.Nazwisko, u.Haslo, u.Uprawnienia, p.PESEL, p.Data_urodzenia, p.Plec
    INTO p_imie, p_nazwisko, p_haslo, p_uprawnienia, p_pesel, p_data_urodzenia, p_plec
    FROM Uzytkownicy u
    JOIN Pacjenci p ON u.ID = p.ID_Uzytkownika
    WHERE UPPER(u.Login) = UPPER(p_login);
END;
/

create PROCEDURE GetLekarze(
    p_miasto IN VARCHAR2,
    p_specjalizacja IN VARCHAR2,
    cur_out OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN cur_out FOR
    SELECT l.Imie, l.Nazwisko, s.Nazwa_specjalizacji, m.Nazwa_miasta
    FROM Lekarze l
    JOIN Specjalizacje s ON l.ID_Specjalizacji = s.ID_Specjalizacji
    JOIN Miasta m ON l.ID_Miasta = m.ID_Miasta
    WHERE (p_miasto IS NULL OR m.Nazwa_miasta = p_miasto)
    AND (p_specjalizacja IS NULL OR s.Nazwa_specjalizacji = p_specjalizacja);
END GetLekarze;
/

create PROCEDURE UPDATE_PACJENT(
    p_id_uzytkownika IN NUMBER,
    p_imie IN VARCHAR2,
    p_nazwisko IN VARCHAR2,
    p_data_urodzenia IN DATE,
    p_plec IN CHAR,
    p_error_message OUT VARCHAR2
) AS
BEGIN
    UPDATE Pacjenci
    SET Imie = p_imie,
        Nazwisko = p_nazwisko,
        Data_urodzenia = p_data_urodzenia,
        Plec = p_plec
    WHERE ID_UZYTKOWNIKA = p_id_uzytkownika;

    IF SQL%ROWCOUNT = 0 THEN
        p_error_message := 'Nie znaleziono rekordu z ID_UZYTKOWNIKA = ' || p_id_uzytkownika;
    ELSE
        p_error_message := 'Dane zostały pomyślnie zaktualizowane.';
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        p_error_message := SQLERRM;
END UPDATE_PACJENT;
/

create FUNCTION PESEL_EXISTS(p_pesel IN VARCHAR2) RETURN NUMBER IS
    v_count NUMBER;
BEGIN
    SELECT COUNT(*) INTO v_count
    FROM Pacjenci
    WHERE PESEL = p_pesel;

    RETURN v_count;
END PESEL_EXISTS;
/

create PROCEDURE ADD_MEDICINE_TO_RECEIPT(
    p_id_receipty IN NUMBER,
    p_id_leku IN NUMBER,
    p_ilosc_sztuk IN NUMBER
) IS
BEGIN
    INSERT INTO RECEPTY_LEKI (ID_RECEPTY, ID_LEKU, ILOSC_SZTUK)
    VALUES (p_id_receipty, p_id_leku, p_ilosc_sztuk);
END;
/

create FUNCTION GENERATE_UNIQUE_KOD_RECEIPTY
RETURN VARCHAR2 IS
    v_kod_receipty VARCHAR2(6);
    v_count NUMBER;
BEGIN
    LOOP
        -- Generowanie losowego 6-cyfrowego kodu
        v_kod_receipty := LPAD(TO_CHAR(FLOOR(DBMS_RANDOM.VALUE(0, 999999))), 6, '0');

        -- Sprawdzenie, czy kod jest unikalny
        SELECT COUNT(*)
        INTO v_count
        FROM RECEPTY
        WHERE KOD_RECEPTY = v_kod_receipty;

        -- Jeśli kod jest unikalny, wyjście z pętli
        EXIT WHEN v_count = 0;
    END LOOP;

    RETURN v_kod_receipty;
END;
/

create PROCEDURE ADD_RECEIPTA(
    P_ID_PACJENTA IN NUMBER,
    P_ID_LEKARZA IN NUMBER,
    P_DATA_WYSTAWIENIA IN DATE,
    P_KOD_RECEIPTY OUT VARCHAR2,
    P_ID_RECEIPTY OUT NUMBER
) AS
    v_count NUMBER;
    v_data_wygasniecia DATE;
BEGIN
    -- Sprawdzenie, czy ID pacjenta jest prawidłowe
    SELECT COUNT(1) INTO v_count FROM Pacjenci WHERE ID = P_ID_PACJENTA;
    IF v_count = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Invalid Pacjent ID');
    END IF;

    -- Sprawdzenie, czy ID lekarza jest prawidłowe
    SELECT COUNT(1) INTO v_count FROM Lekarze WHERE ID = P_ID_LEKARZA;
    IF v_count = 0 THEN
        RAISE_APPLICATION_ERROR(-20002, 'Invalid Lekarz ID');
    END IF;

    -- Generowanie unikalnego kodu recepty
    P_KOD_RECEIPTY := GENERATE_UNIQUE_KOD_RECEIPTY;

    -- Pobieranie nowego ID z sekwencji
    SELECT RECEPTY_SEQ.NEXTVAL INTO P_ID_RECEIPTY FROM DUAL;

    -- Obliczanie daty wygaśnięcia
    v_data_wygasniecia := ADD_MONTHS(P_DATA_WYSTAWIENIA, 1);

    -- Wstawianie nowej recepty
    INSERT INTO RECEPTY (ID_RECEPTY, ID_PACJENTA, ID_LEKARZA, DATA_WYSTAWIENIA, KOD_RECEPTY, STATUS, DATA_WYGASNIECIA)
    VALUES (P_ID_RECEIPTY, P_ID_PACJENTA, P_ID_LEKARZA, P_DATA_WYSTAWIENIA, P_KOD_RECEIPTY, 'Do zrealizowania', v_data_wygasniecia);

    COMMIT;
END;
/

create PROCEDURE ADD_RECEIPTA_LEKI (
    P_ID_RECEIPTY IN NUMBER,
    P_ID_LEKU IN NUMBER,
    P_ILOSC_SZTUK IN NUMBER
) IS
BEGIN
    INSERT INTO RECEPTY_LEKI (ID_RECEPTY, ID_LEKU, ILOSC_SZTUK)
    VALUES (P_ID_RECEIPTY, P_ID_LEKU, P_ILOSC_SZTUK);
END;
/

create PROCEDURE UPDATE_STATUS_RECEPTY IS
BEGIN
    UPDATE RECEPTY
    SET STATUS = 'Wygasła'
    WHERE DATA_WYGASNIECIA <= SYSDATE
      AND STATUS = 'Do zrealizowania';

    COMMIT;
END;
/

create PROCEDURE UPDATE_RECEPTY_STATUS AS
BEGIN
    UPDATE RECEPTY
    SET STATUS = 'Wygasła'
    WHERE DATA_WYGASNIECIA <= SYSDATE AND STATUS = 'Do zrealizowania';
    COMMIT;
END;
/

create PROCEDURE GET_RECEPTA_LEKI_DETAILS (
    p_recepta_id IN NUMBER,
    p_apteka_id IN NUMBER,
    cur OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN cur FOR
        SELECT
            L.Nazwa_leku,
            RL.Ilosc_sztuk,
            CASE
                WHEN A.ID_Leku IS NOT NULL THEN 'Tak'
                ELSE 'Nie'
            END AS Dostepnosc,
            A.Ilosc_dostepnych_sztuk,
            A.Cena
        FROM
            Recepty_Leki RL
            JOIN Leki L ON RL.ID_Leku = L.ID_Leku
            LEFT JOIN Asortyment A ON A.ID_Leku = L.ID_Leku AND A.ID_Apteki = p_apteka_id
        WHERE
            RL.ID_Recepty = p_recepta_id;
END;
/

create PROCEDURE ADD_LEK_TO_ASORTYMENT(
    p_id_apteki IN NUMBER,
    p_id_leku IN NUMBER,
    p_ilosc_sztuk IN NUMBER,
    p_cena IN NUMBER
) AS
BEGIN
    INSERT INTO Asortyment (ID_Asortymentu, ID_Apteki, ID_Leku, Cena, Ilosc_dostepnych_sztuk)
    VALUES (Asortyment_SEQ.NEXTVAL, p_id_apteki, p_id_leku, p_cena, p_ilosc_sztuk);
    COMMIT;
END;
/

-- Przykładwe dane:
INSERT INTO MIASTA (ID_MIASTA, NAZWA_MIASTA) VALUES (1, 'Warszawa');
INSERT INTO MIASTA (ID_MIASTA, NAZWA_MIASTA) VALUES (2, 'Kraków');
INSERT INTO MIASTA (ID_MIASTA, NAZWA_MIASTA) VALUES (3, 'Gdańsk');

INSERT INTO APTEKI (ID_APTEKI, NAZWA_APTEKI, ULICA, NUMER, ID_MIASTA) VALUES (1, 'Apteka Centrum', 'Marszałkowska', '1', 1);
INSERT INTO APTEKI (ID_APTEKI, NAZWA_APTEKI, ULICA, NUMER, ID_MIASTA) VALUES (2, 'Apteka Krakowska', 'Grodzka', '2', 2);
INSERT INTO APTEKI (ID_APTEKI, NAZWA_APTEKI, ULICA, NUMER, ID_MIASTA) VALUES (3, 'Apteka Gdańska', 'Długa', '3', 3);

INSERT INTO SPECJALIZACJE (ID_SPECJALIZACJI, NAZWA_SPECJALIZACJI) VALUES (1, 'Kardiolog');
INSERT INTO SPECJALIZACJE (ID_SPECJALIZACJI, NAZWA_SPECJALIZACJI) VALUES (2, 'Dermatolog');
INSERT INTO SPECJALIZACJE (ID_SPECJALIZACJI, NAZWA_SPECJALIZACJI) VALUES (3, 'Pediatra');

INSERT INTO LEKI (ID_LEKU, NAZWA_LEKU, OPIS, ID_SPECJALIZACJI) VALUES (1, 'Aspiryna', 'Lek przeciwbólowy', 1);
INSERT INTO LEKI (ID_LEKU, NAZWA_LEKU, OPIS, ID_SPECJALIZACJI) VALUES (2, 'Ibuprofen', 'Lek przeciwzapalny', 2);
INSERT INTO LEKI (ID_LEKU, NAZWA_LEKU, OPIS, ID_SPECJALIZACJI) VALUES (3, 'Paracetamol', 'Lek przeciwgorączkowy', 3);

INSERT INTO CHOROBY (ID_CHOROBY, NAZWA_CHOROBY, OBJAWY, OPIS) VALUES (1, 'Przeziębienie', 'Kaszel, katar', 'Choroba wirusowa');
INSERT INTO CHOROBY (ID_CHOROBY, NAZWA_CHOROBY, OBJAWY, OPIS) VALUES (2, 'Grypa', 'Gorączka, ból mięśni', 'Choroba wirusowa');
INSERT INTO CHOROBY (ID_CHOROBY, NAZWA_CHOROBY, OBJAWY, OPIS) VALUES (3, 'Alergia', 'Kichanie, swędzenie', 'Reakcja alergiczna');

INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (1, 'piotr', 'zaq1@WSX', 'Pacjent');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (2, 'lekarz1', 'zaq1@WSX', 'Lekarz');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (3, 'lekarz2', 'zaq1@WSX', 'Lekarz');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (4, 'lekarz3', 'zaq1@WSX', 'Lekarz');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (5, 'lekarz4', 'zaq1@WSX', 'Lekarz');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (6, 'lekarz5', 'zaq1@WSX', 'Lekarz');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (7, 'lekarz6', 'zaq1@WSX', 'Lekarz');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (8, 'lekarz7', 'zaq1@WSX', 'Lekarz');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (9, 'lekarz8', 'zaq1@WSX', 'Lekarz');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (10, 'lekarz9', 'zaq1@WSX', 'Lekarz');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (11, 'farm1', 'zaq1@WSX', 'Farmaceuta');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (12, 'farm2', 'zaq1@WSX', 'Farmaceuta');
INSERT INTO UZYTKOWNICY (ID, LOGIN, HASLO, UPRAWNIENIA) VALUES (13, 'farm3', 'zaq1@WSX', 'Farmaceuta');

INSERT INTO PACJENCI (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, PESEL, DATA_URODZENIA, PLEC) VALUES (1, 1, 'Piotr', 'Kowalski', '12345678901', TO_DATE('1980-01-01', 'YYYY-MM-DD'), 'M');

INSERT INTO LEKARZE (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_SPECJALIZACJI, NUMER_PWZ, ID_MIASTA, DATA_URODZENIA, PLEC) VALUES (1, 2, 'Jan', 'Nowak', 1, '1234567', 1, TO_DATE('1970-01-01', 'YYYY-MM-DD'), 'M');
INSERT INTO LEKARZE (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_SPECJALIZACJI, NUMER_PWZ, ID_MIASTA, DATA_URODZENIA, PLEC) VALUES (2, 3, 'Adam', 'Zieliński', 2, '2345678', 2, TO_DATE('1975-02-02', 'YYYY-MM-DD'), 'M');
INSERT INTO LEKARZE (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_SPECJALIZACJI, NUMER_PWZ, ID_MIASTA, DATA_URODZENIA, PLEC) VALUES (3, 4, 'Ewa', 'Wiśniewska', 3, '3456789', 3, TO_DATE('1980-03-03', 'YYYY-MM-DD'), 'F');
INSERT INTO LEKARZE (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_SPECJALIZACJI, NUMER_PWZ, ID_MIASTA, DATA_URODZENIA, PLEC) VALUES (4, 5, 'Anna', 'Kowalczyk', 1, '4567890', 1, TO_DATE('1985-04-04', 'YYYY-MM-DD'), 'F');
INSERT INTO LEKARZE (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_SPECJALIZACJI, NUMER_PWZ, ID_MIASTA, DATA_URODZENIA, PLEC) VALUES (5, 6, 'Tomasz', 'Kamiński', 2, '5678901', 2, TO_DATE('1990-05-05', 'YYYY-MM-DD'), 'M');
INSERT INTO LEKARZE (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_SPECJALIZACJI, NUMER_PWZ, ID_MIASTA, DATA_URODZENIA, PLEC) VALUES (6, 7, 'Marta', 'Lewandowska', 3, '6789012', 3, TO_DATE('1995-06-06', 'YYYY-MM-DD'), 'F');
INSERT INTO LEKARZE (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_SPECJALIZACJI, NUMER_PWZ, ID_MIASTA, DATA_URODZENIA, PLEC) VALUES (7, 8, 'Krzysztof', 'Wójcik', 1, '7890123', 1, TO_DATE('1975-07-07', 'YYYY-MM-DD'), 'M');
INSERT INTO LEKARZE (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_SPECJALIZACJI, NUMER_PWZ, ID_MIASTA, DATA_URODZENIA, PLEC) VALUES (8, 9, 'Zofia', 'Kwiatkowska', 2, '8901234', 2, TO_DATE('1980-08-08', 'YYYY-MM-DD'), 'F');
INSERT INTO LEKARZE (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_SPECJALIZACJI, NUMER_PWZ, ID_MIASTA, DATA_URODZENIA, PLEC) VALUES (9, 10, 'Piotr', 'Kaczmarek', 3, '9012345', 3, TO_DATE('1985-09-09', 'YYYY-MM-DD'), 'M');

INSERT INTO FARMACEUCI (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_APTEKI, DATA_URODZENIA, PLEC) VALUES (1, 11, 'Alicja', 'Nowicka', 1, TO_DATE('1980-10-10', 'YYYY-MM-DD'), 'F');
INSERT INTO FARMACEUCI (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_APTEKI, DATA_URODZENIA, PLEC) VALUES (2, 12, 'Michał', 'Król', 2, TO_DATE('1985-11-11', 'YYYY-MM-DD'), 'M');
INSERT INTO FARMACEUCI (ID, ID_UZYTKOWNIKA, IMIE, NAZWISKO, ID_APTEKI, DATA_URODZENIA, PLEC) VALUES (3, 13, 'Elżbieta', 'Pawlak', 3, TO_DATE('1990-12-12', 'YYYY-MM-DD'), 'F');

INSERT INTO RECEPTY_LEKI (ID_RECEPTY, ID_LEKU, ILOSC_SZTUK) VALUES (1, 1, 1);

INSERT INTO ASORTYMENT (ID_ASORTYMENTU, ID_APTEKI, ID_LEKU, CENA, ILOSC_DOSTEPNYCH_SZTUK) VALUES (1, 1, 1, 10.00, 100);
INSERT INTO ASORTYMENT (ID_ASORTYMENTU, ID_APTEKI, ID_LEKU, CENA, ILOSC_DOSTEPNYCH_SZTUK) VALUES (2, 2, 2, 20.00, 200);
INSERT INTO ASORTYMENT (ID_ASORTYMENTU, ID_APTEKI, ID_LEKU, CENA, ILOSC_DOSTEPNYCH_SZTUK) VALUES (3, 3, 3, 30.00, 300);
