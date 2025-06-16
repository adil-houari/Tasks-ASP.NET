# 🧪 Test Doubles Practice – Notes App & Yahtzee 🎲

This project contains two testing exercises developed in C# with ASP.NET Core and xUnit.  
It focuses on implementing **unit tests with test doubles**, validating both service logic and game rules.

## 📌 Exercise 1 – Notes Service 📝

A simple service to store user notes, structured with:
- NotesRepository for data persistence (CRUD operations)
- NotesService for business logic, which delegates repository access

### 🎯 Goals
- Write unit tests for NotesService
- Use **NSubstitute** to mock the INotesRepository
- Apply proper dependency injection patterns
- Focus on test isolation & behavior verification

### ✅ Key Testing Topics
- Mocking repository interactions
- Verifying service methods handle data correctly
- Interface-based design for better testability

---

## 📌 Exercise 2 – Yahtzee Game 🎲

Basic implementation of the Yahtzee game.  
The logic resides in the YahtzeeGame class, supporting 5 dice rolls and score calculations.

### 🎯 Goals
- Write 6 unit tests for 3 selected Yahtzee scoring categories:
  - One test with score = 0
  - One test with score > 0
- Use **test doubles** to control randomness (mock dice values)

---

## 🛠 Tech Stack

- C#
- ASP.NET Core
- xUnit (Testing framework)
- NSubstitute (Mocking library)

---

## 🚀 Run the Tests

--bash
# Restore dependencies
dotnet restore

# Run all tests
dotnet test
