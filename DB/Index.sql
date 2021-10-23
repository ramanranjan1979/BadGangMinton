  CREATE INDEX indx_Attendance_AttendanceDate_PersonId ON [dbo].[Attendance] (AttendanceDate, PersonId);

  CREATE INDEX indx_transaction_transactionTypeId_PersonId ON [dbo].[Transaction] (TransactionTypeId, PersonId);

  CREATE INDEX indx_Log_logTypeId_PersonId ON [dbo].[Log] (LogTypeId, PersonId);

  CREATE INDEX indx_Log_mailoutTypeId_PersonId ON [dbo].[MailoutQueue] (MailoutTypeId, PersonId);