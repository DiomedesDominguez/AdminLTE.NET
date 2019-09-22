﻿declare @procName varchar(500)
declare cur cursor 

for select [name] from sys.objects where type = 'p' AND is_ms_shipped = 0 
open cur
fetch next from cur into @procName
while @@fetch_status = 0
begin
    exec('drop procedure [' + @procName + ']')
    fetch next from cur into @procName
end
close cur
deallocate cur