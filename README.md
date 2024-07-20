Task Management System

This project is related to task management 

Task Management for Employees:

  Create, view, update, and delete tasks.
  Attach documents to tasks.
  Add notes to tasks.
  Mark tasks as complete.

Database Design
    Tables
    Users: Store user details.
    
    UserId (PK)
    Name
    Email
    Role (Employee, Manager, Admin)
    Tasks: Store task details.
    
    TaskId (PK)
    Title
    Description
    Status (Pending, In Progress, Completed)
    DueDate
    CreatedBy (FK to Users)
    AssignedTo (FK to Users)
    Notes: Store notes attached to tasks.
    
    NoteId (PK)
    TaskId (FK to Tasks)
    Content
    CreatedBy (FK to Users)
    Documents: Store documents attached to tasks.
    
    DocumentId (PK)
    TaskId (FK to Tasks)
    FilePath
    UploadedBy (FK to Users)
