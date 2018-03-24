REM uses LiteDb to access file "loc.db" extracting localizations with the given filter
dotnet FluiTec.AppFx.Localization.Exporter.dll -t litedb -s "C:\Development\Bitbucket\FluiTec\AppFx\src\FluiTec.AppFx.AspNetCore.Examples.LocalizationExample\loc.db" -f FluiTec.AppFx.AspNetCore.Examples.LocalizationExample.Models

REM uses Reflection to access file "FluiTec.AppFx.AspNetCore.Examples.LocalizationExample.dll" extracting localizations with the given filter
dotnet FluiTec.AppFx.Localization.Exporter.dll -t assembly -s "C:\Development\Bitbucket\FluiTec\AppFx\src\FluiTec.AppFx.AspNetCore.Examples.LocalizationExample\bin\Debug\netcoreapp2.0\FluiTec.AppFx.AspNetCore.Examples.LocalizationExample.dll" -f FluiTec.AppFx.AspNetCore.Examples.LocalizationExample.Models