”Write a class in C# that logs 10.000 lines as fast as possible to a text file. 
The log file generated should have all log entries ordered in the order they were added by callers”.

This project assimilates logs and keeps them in sequence
Once there are 10.000 entries received, they are logged to a file
Any more than that received will be sent over fast in the next batch and so on.

Testing:
Check fact file is saved
Theories around what happens for more, less, lines and how to deal with these

Todo:
How to deal with more saves? Should there be a new file created and tests and edge cases needed for this