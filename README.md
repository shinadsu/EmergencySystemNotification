# EmergencySystemNotification

## Описание

Сервис для массовой рассылки уведомлений выбранным пользователям (в разработке). На данный момент реализована отправка уведомлений по электронной почте. В разработке находятся нотификации по телефону и в Telegram. В будущем проект будет переписан на ASP.NET Core.

## Текущие возможности

### 1. Отправка сообщений по электронной почте
Используется библиотека [MailKit](https://github.com/jstedfast/MailKit) для отправки уведомлений на электронную почту.

## В разработке

### 1. Телефонные уведомления
Разработка системы отправки уведомлений на телефоны.

### 2. Уведомления в Telegram
Разработка системы отправки уведомлений в Telegram.

## Планируемое

- Переписать проект на ASP.NET Core.
- Добавить unit-тестирование для обеспечения надёжности кода.

## Зависимости приложения

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <DockerDefaultTargetOS>Windows</DockerDefaultTargetOS>
    <DockerfileContext>.</DockerfileContext>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MailKit" Version="4.7.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.8" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.8">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="8.0.8" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.8" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.8">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.VisualStudio.Azure.Containers.Tools.Targets" Version="1.21.0" />
  </ItemGroup>

</Project>
