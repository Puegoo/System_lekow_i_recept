# PillPal

<div align="center">
  <img src="Docs/PillPal_banner.png" width="100%" alt="Banner">
</div>

## Table of Contents

1. [Project Overview](#project-overview)
2. [System Features](#system-features)
3. [Database Procedures](#database-procedures)
4. [Database Schema](#database-schema)
5. [Sample Data](#sample-data)
6. [Gallery](#gallery)
7. [Authors](#authors)

---

## Project Overview

Our goal is to create a comprehensive system for managing medications, prescriptions, and patient data. This project aims to streamline interactions between patients, doctors, and pharmacists by providing a web platform for easy management of treatment information.

---

## System Features

* **Authentication and Login**
  Users can log in using individual accounts.

* **Patient Data Management**
  Patients can register, view their personal information, and access their prescription history.

* **Prescription Issuance**
  Doctors can issue prescriptions for patients, specifying required medications and dosages.

* **Medication Inventory**
  Pharmacists can add and update available medications in their pharmacy, including quantity and price.

* **Pharmacy Management**
  Stores pharmacy information such as name, location (city, street, number), and medication inventory.

* **Prescription Status Tracking**
  Patients can track prescription status (fulfilled or pending) at the pharmacy.

---

## Database Procedures

* **Prescription Management**
  PL/SQL procedures for adding, updating, and deleting prescriptions and their medications.

* **Inventory Management**
  PL/SQL procedures for adding and updating medication stock levels in pharmacies.

* **Data Security**
  PL/SQL functions for data validation, generating unique prescription codes, and verifying unique national IDs (PESEL).

---

## Database Schema

**ERD Diagram**

<div style="text-align:center; margin-bottom:24px;">
  <img src="Docs/Baza.png" alt="ERD Diagram" width="100%">
</div>

---

## Sample Data

* **Patient**
  Login: `piotr`
  Password: `zaq1@WSX`

* **Doctor**
  Login: `doctor1`, `doctor2`, … `doctor9`
  Password: `zaq1@WSX`

* **Pharmacist**
  Login: `pharm1`, `pharm2`, `pharm3`
  Password: `zaq1@WSX`

* **Database User**
  Login: `hr`
  Password: `oracle`

---

## Gallery

### Home Page

<div align="center">
  <img src="Docs/strona_glowna.png" width="100%" alt="Home Page">
</div>

---

### Login Screens

<table>
  <tr>
    <td align="center">
      <img src="Docs/log_pac.png" width="90%"><br>Patient Login
    </td>
    <td align="center">
      <img src="Docs/log_lek.png" width="90%"><br>Doctor Login
    </td>
  </tr>
  <tr>
    <td colspan="2" align="center">
      <img src="Docs/log_far.png" width="45%"><br>Pharmacist Login
    </td>
  </tr>
</table>

---

### Patient Views

<table>
  <tr>
    <td align="center">
      <img src="Docs/panel_pac.png" width="90%"><br>Patient Dashboard
    </td>
    <td align="center">
      <img src="Docs/panel_pac_lek.png" width="90%"><br>Patient Medications
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Docs/panel_pac_edyt.png" width="90%"><br>Edit Patient Details
    </td>
    <td align="center">
      <img src="Docs/panel_pac_rec.png" width="90%"><br>Patient Prescriptions
    </td>
  </tr>
</table>

---

### Doctor Views

<table>
  <tr>
    <td align="center">
      <img src="Docs/panel_lek.png" width="90%"><br>Doctor Dashboard
    </td>
    <td align="center">
      <img src="Docs/panel_lek_rec.png" width="90%"><br>Doctor Prescriptions
    </td>
  </tr>
  <tr>
    <td colspan="2" align="center">
      <img src="Docs/panel_lek_pac.png" width="45%"><br>Doctor’s Patients
    </td>
  </tr>
</table>

---

### Pharmacist Views

<table>
  <tr>
    <td align="center">
      <img src="Docs/panel_far.png" width="90%"><br>Pharmacist Dashboard
    </td>
    <td align="center">
      <img src="Docs/panel_far_rec_szcz.png" width="90%"><br>Prescription Details
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Docs/panel_far_aso.png" width="90%"><br>Pharmacy Inventory
    </td>
    <td align="center">
      <img src="Docs/panel_far_mag.png" width="90%"><br>Inventory Stock
    </td>
  </tr>
  <tr>
    <td colspan="2" align="center">
      <img src="Docs/panel_far_rec.png" width="45%"><br>Pharmacy Prescriptions
    </td>
  </tr>
</table>

## Authors

* Piotr Nowak ([GitHub](https://github.com/Puegoo))
