Task Management System

Task Management for Employees:

Create, view, update, and delete tasks.
Attach documents to tasks.
Add notes to tasks.
Mark tasks as complete.
Task Tracking for Managers/Team Leaders:

View tasks of team members.
Filter tasks by status, due date, and priority.

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
