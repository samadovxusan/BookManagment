BookManagement is a system for managing books, including features such as book registration, validation, and retrieval. The project is built using ASP.NET Core for the backend and follows best practices for data validation and querying.

🚀 Features
Book Registration: Validate and store book details, ensuring uniqueness by title.
Validation: Uses FluentValidation to enforce input rules.
Database Queries: Fetch books with filtering and sorting options.
Soft Deletion: Books can be marked as deleted instead of being removed from the database.
🛠️ Technologies
ASP.NET Core
Entity Framework Core (EF Core)
PostgreSQL (or any configured database)
FluentValidation
Swagger for API Documentation
⚡ Installation
Clone the Repository:

sh
Copy
Edit
git clone https://github.com/samadovxusan/BookManagement.git
cd BookManagement
Configure the Database:

Update the appsettings.json with your database connection string.
Apply migrations:
sh
Copy
Edit
dotnet ef database update
Run the Project:

sh
Copy
Edit
dotnet run
Access API Documentation:

Open: http://localhost:5087/swagger
📜 API Endpoints
Method	Endpoint	Description
POST	/api/books	Add a new book
GET	/api/books	Retrieve all books
GET	/api/books/{id}	Get book details by ID
DELETE	/api/books/{id}	Soft delete a book
📝 License
This project is open-source and available under the MIT License.
