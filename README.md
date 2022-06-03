# SirensDiscordBot
* [UA](https://github.com/correaAlex/SirensDiscordBot#%D0%B4%D0%BB%D1%8F-%D0%BF%D0%BE%D1%87%D0%B0%D1%82%D0%BA%D1%83) Бот повітряних тривог для вашого Discord серверу. Бот використовує API https://sirens.in.ua/#
* [EN](https://github.com/correaAlex/SirensDiscordBot#getting-started) Bot of the air alarms for your Discord server. Bot uses API https://sirens.in.ua/#
## Для початку
### 1. Встановити [Docker](https://docs.docker.com/engine/install/ubuntu/)
### 2. Копіювати репозиторій.
```sh
  $ git clone https://github.com/correaAlex/SirensDiscordBot.git
```
### 3. Перейти в репозиторій 
``` sh 
  $ cd SirensDiscordBot
```
### 4. Змініть ім'я користувача та пароль бази даних в файлах:
*docker-compose.yml*
```yml
  MYSQL_USER: yourUserName
  MYSQL_PASSWORD: yourPassword
```
*App.config*
```xml
  <add key="ConnectionString" value="server=db;port=3306;user=yourUserName;password=yourPassword;database=sirens_bot"/>
```
### 5. Створити [Discrod](https://discordpy.readthedocs.io/en/stable/discord.html) бота
### 6. Додайте токен свого бота в файл *App.config*
```xml
  <add key="Token" value="YOUR_TOKEN"/>
```
### 7. [Додайте](https://discordjs.guide/preparations/adding-your-bot-to-servers.html#bot-invite-links) свого бота до вашого серверу
### 8. Виконайте команду:
```sh
  $ sudo docker-compose up
```
### 8. В текстовому каналі вашого серверу виконайте команду *!start* та слідуйте інструкціям

## Getting started
### 1. Install [Docker](https://docs.docker.com/engine/install/ubuntu/)
### 2. Copy repository.
```sh
  $ git clone https://github.com/correaAlex/SirensDiscordBot.git
```
### 3. Move to folder repository 
``` sh 
  $ cd SirensDiscordBot
```
### 4. Change database settings in files:
*docker-compose.yml*
```yml
  MYSQL_USER: yourUserName
  MYSQL_PASSWORD: yourPassword
```
*App.config*
```xml
  <add key="ConnectionString" value="server=db;port=3306;user=yourUserName;password=yourPassword;database=sirens_bot"/>
```
### 5. Create [Discrod](https://discordpy.readthedocs.io/en/stable/discord.html) bot
### 6. Add bot token *App.config*
```xml
  <add key="Token" value="YOUR_TOKEN"/>
```
### 7. [Invite](https://discordjs.guide/preparations/adding-your-bot-to-servers.html#bot-invite-links) bot to you server
### 8. Run command:
```sh
  $ sudo docker-compose up
```
### 8. In text cahnel in you discord server type *!start* and follow instructions
