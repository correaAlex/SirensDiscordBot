# SirensDiscordBot
* :ukraine: Простий бот повітряних тривог для вашого Discord серверу. Ви можете безкошновно створити власного бота та розмістити його на власному віддаленому сервері (наприклад на [Oracle Cloud Free Tier](https://www.oracle.com/cis/cloud/free/)) за допомогою цієї [інструкції](https://github.com/correaAlex/SirensDiscordBot#%D0%B4%D0%BB%D1%8F-%D0%BF%D0%BE%D1%87%D0%B0%D1%82%D0%BA%D1%83), або використовувати готове [рішення](https://discord.com/api/oauth2/authorize?client_id=982001545266733146&permissions=8&scope=bot%20bot) на вашому Discord серверу. Бот використовує стороннє [API](https://sirens.in.ua/#).
* :uk: A simple air-raid bot for your Discord server. You can create your own bot for free and place it on your own remote server (e.g. on [Oracle Cloud Free Tier](https://www.oracle.com/cloud/free/?source=:ow:o:h:po:OHPPanel1nav0625&intcmp=:ow:o:h:po:OHPPanel1nav0625)) using these [instructions](https://github.com/correaAlex/SirensDiscordBot#getting-started), or use a ready-made solution on your Discrod server. Bot uses [API](https://sirens.in.ua/#).
## Для початку
### 1. Встановити [Docker](https://docs.docker.com/engine/install/ubuntu/)
### 2. Встановити [Docker Compose](https://docs.docker.com/compose/install/)
### 3. Копіювати репозиторій.
```sh
  $ git clone https://github.com/correaAlex/SirensDiscordBot.git
```
### 4. Перейти в репозиторій 
``` sh 
  $ cd SirensDiscordBot
```
### 5. Змініть ім'я користувача та пароль бази даних в файлах:
*docker-compose.yml*
```yml
  MYSQL_USER: yourUserName
  MYSQL_PASSWORD: yourPassword
```
*App.config*
```xml
  <add key="ConnectionString" value="server=db;port=3306;user=yourUserName;password=yourPassword;database=sirens_bot"/>
```
### 6. Створити [Discrod](https://discordpy.readthedocs.io/en/stable/discord.html) бота
### 7. Додайте токен свого бота в файл *App.config*
```xml
  <add key="Token" value="YOUR_TOKEN"/>
```
### 8. [Додайте](https://discordjs.guide/preparations/adding-your-bot-to-servers.html#bot-invite-links) свого бота до вашого серверу
### 9. Виконайте команду:
```sh
  $ sudo docker-compose up
```
### 10. В текстовому каналі вашого серверу виконайте команду `!start` та слідуйте інструкціям

## Getting started
### 1. Install [Docker](https://docs.docker.com/engine/install/ubuntu/)
### 2. Instal; [Docker Compose](https://docs.docker.com/compose/install/)
### 3. Copy repository.
```sh
  $ git clone https://github.com/correaAlex/SirensDiscordBot.git
```
### 4. Move to folder repository 
``` sh 
  $ cd SirensDiscordBot
```
### 5. Change database settings in files:
*docker-compose.yml*
```yml
  MYSQL_USER: yourUserName
  MYSQL_PASSWORD: yourPassword
```
*App.config*
```xml
  <add key="ConnectionString" value="server=db;port=3306;user=yourUserName;password=yourPassword;database=sirens_bot"/>
```
### 6. Create [Discrod](https://discordpy.readthedocs.io/en/stable/discord.html) bot
### 7. Add bot token *App.config*
```xml
  <add key="Token" value="YOUR_TOKEN"/>
```
### 8. [Invite](https://discordjs.guide/preparations/adding-your-bot-to-servers.html#bot-invite-links) bot to you server
### 9. Run command:
```sh
  $ sudo docker-compose up
```
### 10. In text cahnel in you discord server type `!start` and follow instructions
