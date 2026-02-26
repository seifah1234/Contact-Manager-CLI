# Contact Manager CLI

## How the Application Works

The Contact Manager CLI is a command-line application built using C# with Object-Oriented Programming and SOLID principles.

### Application Flow

1. When the application starts, it loads all contacts from a JSON file into memory.
2. The main menu is displayed to the user.
3. The user can choose from the following options:
   - Add Contact
   - Edit Contact
   - Delete Contact
   - View Contact
   - List Contacts
   - Search
   - Filter
   - Save
   - Exit
4. All operations (add, edit, delete, search, filter) are performed on an in-memory collection to ensure fast execution.
5. Data is only written back to the JSON file when the user selects **Save**.

---

## Architecture Overview

The application follows a layered structure:

- **Presentation Layer**: Handles CLI interaction only.
- **Business Layer (ContactService)**: Manages contact logic, ID generation, validation, and search/filter operations.
- **Storage Layer (JsonStorageService)**: Responsible only for reading and writing JSON data.

Dependencies are injected using interfaces to maintain loose coupling and follow SOLID principles.

---

## Search vs Filter

### Search
- Used to find a specific contact.
- Requires the full keyword (exact match).
- Typically returns a single result.
- Example: Search by exact Name or full email.

### Filter
- Used to retrieve multiple contacts based on a condition.
- Can match partial values (e.g., beginning of a name).
- Returns a collection of results.
- Example: Filter contacts whose name starts with "A".

---

## Performance Design

- Contacts are loaded once at startup.
- All operations are performed in memory.
- A dictionary is used for fast lookup by ID (O(1)).
- This avoids repeated file access and prevents blocking operations.
