﻿![Version](https://img.shields.io/badge/CheckBackups-v2.0-6d4aff?style=for-the-badge&logo=csharp&logoColor=white)
![C#](https://img.shields.io/badge/.NET8-6d4aff?style=for-the-badge&logo=csharp&logoColor=white)
![C#](https://img.shields.io/badge/C%23-6d4aff?style=for-the-badge&logo=csharp&logoColor=white)
![Rider](https://img.shields.io/badge/Rider-000000.svg?style=for-the-badge&logo=Rider&logoColor=white&color=black&labelColor=crimson)

# CheckBackups
**CheckBackups** - это скрипт для проверки актуальности SQL/Veeam-бэкапов на серверах АСКУЭ.
Скрипт переписан с нуля на dotnet 8, поэтому он стал кроссплатформенным и оптимизированным.

## Использование
Склонировать репозиторий
```
git clone https://github.com/woundmee/check-askue-backups.git
```

Перейти в каталог с проектом
```
cd check-askue-backups-main/
```

Собрать и запустить скрипт
```
dotnet build
dotnet run
```

_<small>После сборки появится исполняемый файл (в зависимости от платформы), если Windows - `.exe`, если Linux - `CheckBackups`, которому необходимо выдать права `+x` и выполнить: `./CheckBackups -h`</small>_

### Доп. информация

- Для SQL скрипт реагирует только на следующую структуру и наименования файлов:
  - `../Day/Pyramid2_backup_Day_2025_07_18.bak`
  - `../Month/Pyramid2_backup_Month_2025_07_01.bak`
  - `../Year/Pyramid2_backup_Year_2025_01_01.bak`

- Для Veeam:
  - `../System Backup2025-07-19.vib`