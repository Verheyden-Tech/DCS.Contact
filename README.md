# DCS.Contact

[![MIT License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

## Overview

`DCS.Contact` is a comprehensive C# solution for managing all contact-related data within the Data Control System (DCS). It serves as a central address book, providing a robust backend and user interface to capture and organize contact information for customers, suppliers, and other parties.

This document serves as a technical overview for developers and future team members to understand the architecture and purpose of the `DCS.Contact` component within the main Data Control System (DCS).

## Features

*   **Comprehensive Contact Management:** Full CRUD (Create, Read, Update, Delete) operations for contacts.
*   **Detailed Contact Information:** Manage addresses, multiple email addresses, and phone numbers for each contact.
*   **Categorization and Typing:** Assign types and categories to contacts for logical grouping and better organization.
*   **Profile Pictures:** Add profile pictures to contacts for easier identification.
*   **Search and Filter:** Quickly find contacts using powerful search and filter capabilities.
*   **Future Integrations:** Integrations with calendar and mail systems are planned for easy creation of appointments and communication.
*   **Integrated Logging:** Logs user activities and critical system events for monitoring and auditing purposes.

## Getting Started

To get the project up and running on your local machine, follow these steps.

### Prerequisites

*   .NET 7 SDK
*   Windows 7 or later
*   MS SQL Server

### Installation

1.  Clone the repository:
    ```sh
    git clone https://github.com/Verheyden-Tech/DCS.Contact.git
    ```
2.  Navigate to the project directory:
    ```sh
    cd DCS.Contact
    ```
3.  Restore the .NET dependencies:
    ```sh
    dotnet restore
    ```
4.  Ensure the database is configured and set up as required by the project.

## Usage Example

A primary use case is the creation and management of contacts such as customers or suppliers. Through the context menu in the user interface, a new contact can be created, an existing one edited, or removed. The system is designed as a central address book where all relevant information can be collected. A contact can be flexibly assigned multiple email addresses and phone numbers.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For inquiries, please contact us at verheyden.tech@gmail.com.