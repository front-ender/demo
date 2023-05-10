”Write a class in C# that logs 10.000 lines as fast as possible to a text file. 
The log file generated should have all log entries ordered in the order they were added by callers”.

This project assimilates logs and keeps them in sequence
Once there are 10.000 entries received, they are logged to a file
Any more than that received will be sent over fast in the next batch and so on.