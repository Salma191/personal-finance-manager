# SmartFinance - Personal Finance Management Platform

[![Build Status](https://github.com/YourUsername/SmartFinance/actions/workflows/deploy.yml/badge.svg)](https://github.com/YourUsername/SmartFinance/actions/workflows/deploy.yml)

**SmartFinance** is a personal finance management platform that helps users track income, expenses, and budgets, while providing clear dashboards and insightful reports for better financial visibility.

## Features

- User authentication and authorization
- Income and expense tracking
- Budget management and financial reports
- Responsive web interface
- Secure connection to Azure SQL Database
- Incremental CI/CD deployment using GitHub Actions

## Technologies

- Backend: **.NET 8**
- Frontend: **.NET (Razor Pages / Blazor)**
- Database: **Azure SQL**
- Deployment: **Azure App Service**, **GitHub Actions**
- Version Control: **Git / GitHub**
- CI/CD: **GitHub Actions workflows**


## Architecture

- **Backend**: RESTful APIs for managing finance data
- **Frontend**: .NET Razor Pages / Blazor for interactive UI
- **Database**: Azure SQL Database with secure access from App Service
- **CI/CD Pipeline**: GitHub Actions builds and deploys automatically on push to `main`


## Setup / Local Development

1. Clone the repository:
```bash
git clone https://github.com/Salma191/SmartFinance.git
cd SmartFinance
```
2. Configure Azure SQL connection string in appsettings.json:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=tcp:<your-server>.database.windows.net,1433;Initial Catalog=SmartFinanceDB;User ID=<username>;Password=<password>;Encrypt=True;"
}
```

3. Run the backend:
```bash
dotnet run --project SmartFinance.Backend
```

4. Run the frontend:
```bash
dotnet run --project SmartFinance.Frontend
```

5. Access the app at [https://localhost:5001](https://localhost:5001)

## Deployment

The project uses GitHub Actions CI/CD to deploy automatically to Azure App Service:
- Push to the main branch triggers build and deployment.
- Backend and frontend are deployed together.
- Database migrations are applied automatically if configured.

## Contributing

Fork the repository
1. Create a feature branch (```git checkout -b feature/my-feature```)
2. Commit your changes (```git commit -m 'Add my feature'```)
3. Push to the branch (```git push origin feature/my-feature```)
4. Open a Pull Request

## License

This project is licensed under the MIT License. 
