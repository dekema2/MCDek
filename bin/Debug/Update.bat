::Version 3
TASKKILL /pid %2 /F
if exist MCDek_.dll.backup (erase MCDek_.dll.backup)
if exist MCDek_.dll (rename MCDek_.dll MCDek_.dll.backup)
if exist MCDek.new (rename MCDek.new MCDek_.dll)
start MCDek.exe
