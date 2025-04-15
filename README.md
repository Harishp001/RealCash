# RealCash Web Application

**RealCash** is a web-based ASP.NET MVC project that handles user registrations, transactions, and session management. This repository is designed for personal finance management and tracking user transactions securely.

---

## 🚀 Features

- User Registration & Login with Session Management
- Role-based access and authenticated routes
- Add and View Transactions (specific to logged-in user)
- Secure Logout & Redirection
- Styled transaction view with currency formatting
- SQL Server database integration
- Entity Framework for DB operations
- Git-ignored temporary files & build outputs

---

## 🛠️ Tech Stack

- ASP.NET MVC 5 (Visual Studio 2017)
- C#
- SQL Server
- Entity Framework
- HTML/CSS (Razor Views)
- Git for version control

---

## 📂 Folder Structure

```
/RealCash
│
├── /Controllers
│   └── Handles login, logout, transaction actions
├── /Models
│   └── User and Transaction models
├── /Views
│   └── Razor views for Login, Index, Transactions
├── /RealCash.DB
│   └── Entity Framework DB context and operations
├── /Scripts /Content
│   └── UI and CSS files
├── /Properties
│   └── launchSettings.json (ignored in Git)
└── .gitignore
```

---

## 🧑‍💻 Usage Guide

### 1. Clone Repository

```bash
git clone https://github.com/yourusername/realcash.git
```

### 2. Build & Run

- Open the solution in **Visual Studio 2017**
- Build the solution
- Press `F5` or run without debugging

## 🧹 Git Setup

Make sure `.gitignore` includes:

```gitignore
.vs/
bin/
obj/
*.user
*.suo
*.dbmdl
*.log
*.pdb
*.mdf
*.ldf
```

To reset Git tracking after modifying `.gitignore`:

```bash
rm -rf .vs
git rm -r --cached .
git add .
git commit -m "Clean up and apply .gitignore"
```

---

## 🔐 Notes

- `.vs` folder is safe to delete; it's recreated by Visual Studio.
- Don't push build results or user-specific files to GitHub.
- Passwords and connection strings should be kept secure and not committed.

---

## 📸 Screenshots

*Coming Soon* – include login screen, dashboard, and transaction view.

---

## 📃 License

MIT License – feel free to use, improve, and share!

---

## 🙏 Thanks

Thanks to ChatGPT for guiding through ASP.NET MVC setup, database integration, and Git operations 😄
