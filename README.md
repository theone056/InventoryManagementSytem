# Inventory Management System

This project is an Inventory Management System developed using ASP.NET Core. It allows users to manage their inventory by adding, updating, deleting, and searching for items.

## Table of Contents

- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features

- **User Authentication**: Secure user authentication system for managing access to the system.
- **Item Management**: CRUD operations for managing inventory items including adding, updating, deleting, and searching.
- **Category Management**: Ability to categorize items for easier organization and management.
- **Inventory Reporting**: Generate reports on inventory status, such as quantity, categories, etc.
- **User Roles**: Different roles such as admin and regular user with varying levels of access and permissions.
- **Responsive Design**: Responsive design to ensure usability across various devices and screen sizes.

## Requirements

- [.NET Core SDK](https://dotnet.microsoft.com/download) - Ensure you have the .NET Core SDK installed.
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/download) - For development.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - Database system for storing inventory data.

## Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/inventory-management-system.git
    ```

2. **Navigate to the project directory:**

    ```bash
    cd inventory-management-system
    ```

3. **Restore dependencies:**

    ```bash
    dotnet restore
    ```

4. **Update the database:**

    ```bash
    dotnet ef database update
    ```

5. **Run the application:**

    ```bash
    dotnet run
    ```

6. **Open the application in your web browser:**

    ```
    https://localhost:5001
    ```

## Usage

- **Login**: Use your registered credentials to log in to the system.
- **Dashboard**: Access the dashboard to get an overview of the inventory.
- **Manage Items**: Navigate to the item management section to add, edit, delete, or search for items.
- **Manage Categories**: Manage item categories to organize inventory effectively.
- **Generate Reports**: Generate reports on inventory status and trends.
- **Manage Users**: If you have admin privileges, manage user accounts and roles.

## Contributing

Contributions are welcome! If you want to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/improvement`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature/improvement`).
6. Create a new Pull Request.
