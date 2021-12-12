# Xpymb.TestExercises.RPG

<h2>Описание</h2>
Реализовать SPA приложение ( asp.net core + react.js ) представляющее собой хранилище данных рпг-игры. В качестве базы данных предлагается использовать Mongodb. Сервис должен запускаться в Docker контейнерах с помощью docker-compose.



Использовано:

Backend:
- .NET 6
- docker-compose
- MongoDb
- MongoDbExpress
- Swagger
- AutoMapper

Frontend:
- React JS
- react-router-dom
- react-select
- axios

<h2>Issues</h2>
- docker-compose: asp.net образ подгружается с docker hub, из-за того что при создания образа с помощью docker-cli возникает ошибка: "Program does not contain static Main", на данный момент образ создан при помощи VS 2020  

<h2>Как запустить?</h2>

Для запуска проекта необходимы следующие модули:
- docker engine (ссылка: https://docs.docker.com/engine/install/)

<br>Чтобы запустить проект, выполните следующие действия:</br>

1) Клонировать репозиторий

- Через терминал:
<code>git clone https://github.com/Xpymb/Xpymb.TestExercises.GameRepository.git</code>

- Или при помощи GitHub Desktop. 
<br>

2) Перейти в клонированную папку

- Через терминал:
<code>cd Xpymb.TestExercises.GameRepository</code>
<br>

3) Запустить docker-compose

- <code>docker-compose up -d</code>

Будет запущен контейнер с следующими адресами:

- <code>http://localhost:5068</code> Backend (ASP.NET Core)
- <code>http://localhost:3000</code> Frontend (React)
- <code>http://localhost:27017</code> Database (MongoDb)
- <code>http://localhost:8081</code> ВBMS (MongoDb Express)

<h2>Описание API-методов</h2>

Для удобной навигации по REST-API методам был сконфигурирован Swagger, перейти к нему можно по адресу: 
- <code>http://localhost:5068/swagger</code>
<br>

<h3>1) Получить информацию об юните по его id</h3>

Адрес: <code>http://localhost:5068/api/unit/get</code>

Тип метода: GET

<table>
    <tr>Параметры запроса:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id (Обязательный)</td> <td>Id юнита</td>
    </tr>
</table>

Пример запроса:

http://localhost:5068/api/unit/get?id=b21b5b80-7c5f-4b0d-ae1f-eb1d4210e1e5

Пример ответа:

    {
      "id": "b21b5b80-7c5f-4b0d-ae1f-eb1d4210e1e5",
      "hp": 100,
      "maxHp": 100,
      "mana": 100,
      "maxMana": 100,
      "armor": 5,
      "magicResist": 5,
      "x": 83,
      "y": 70,
      "gameClass": {
        "classType": 0,
        "damageType": 0,
        "maxAttackRadius": 10,
        "damage": 11
      }
    }

<table>
    <tr>Параметры ответа:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id юнита</td>
    </tr>
    <tr>
        <td>hp</td> <td>Количество HP юнита (в процентах)</td>
    </tr>
    <tr>
        <td>maxHp</td> <td>Максимальное количество HP юнита (в процентах)</td>
    </tr>
    <tr>
        <td>mana</td> <td>Количество маны юнита (в процентах)</td>
    </tr>
    <tr>
        <td>maxMana</td> <td>Максимальное количество маны юнита (в процентах)</td>
    </tr>
    <tr>
        <td>armor</td> <td>Физическая броня юнита</td>
    </tr>
    <tr>
        <td>magicResist</td> <td>Магическая броня юнита</td>
    </tr>
    <tr>
        <td>x</td> <td>Положение юнита по оси X</td>
    </tr>
    <tr>
        <td>y</td> <td>Положение юнита по оси Y</td>
    </tr>
    <tr>
        <td>gameClass</td> <td>Структура класса юнита: <br> 
      classType - класс юнита в enum; <br> 
      damageType - тип урона юнита; <br>
      maxRadius - максимальная дальность атаки юнита; <br>
      damage - урон юнита</td>
    </tr>
</table>
<br></br>

<h3>2) Получить всех юнитов</h3>

Адрес: <code>http://localhost:5068/api/unit/list</code>


Тип метода: GET

Пример запроса:

http://localhost:5068/api/unit/list

Пример ответа:

    [
      {
        "id": "b21b5b80-7c5f-4b0d-ae1f-eb1d4210e1e5",
        "hp": 100,
        "maxHp": 100,
        "mana": 100,
        "maxMana": 100,
        "armor": 5,
        "magicResist": 5,
        "x": 83,
        "y": 70,
        "gameClass": {
          "classType": 0,
          "damageType": 0,
          "maxAttackRadius": 10,
          "damage": 16
        }
      },
      {
        "id": "ebe639d6-8d43-4bb2-9953-789f4865ee42",
        "hp": 100,
        "maxHp": 100,
        "mana": 100,
        "maxMana": 100,
        "armor": 9,
        "magicResist": 9,
        "x": 76,
        "y": 92,
        "gameClass": {
          "classType": 0,
          "damageType": 0,
          "maxAttackRadius": 10,
          "damage": 15
        }
      }
    ]

<table>
    <tr>Параметры ответа:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id юнита</td>
    </tr>
    <tr>
        <td>hp</td> <td>Количество HP юнита (в процентах)</td>
    </tr>
    <tr>
        <td>maxHp</td> <td>Максимальное количество HP юнита (в процентах)</td>
    </tr>
    <tr>
        <td>mana</td> <td>Количество маны юнита (в процентах)</td>
    </tr>
    <tr>
        <td>maxMana</td> <td>Максимальное количество маны юнита (в процентах)</td>
    </tr>
    <tr>
        <td>armor</td> <td>Физическая броня юнита</td>
    </tr>
    <tr>
        <td>magicResist</td> <td>Магическая броня юнита</td>
    </tr>
    <tr>
        <td>x</td> <td>Положение юнита по оси X</td>
    </tr>
    <tr>
        <td>y</td> <td>Положение юнита по оси Y</td>
    </tr>
    <tr>
        <td>gameClass</td> <td>Структура класса юнита: <br> 
      classType - класс юнита в enum; <br> 
      damageType - тип урона юнита; <br>
      maxRadius - максимальная дальность атаки юнита; <br>
      damage - урон юнита</td>
    </tr>
</table>
<br></br>

<h3>3) Создать новую запись с информацией об игре в базе данных</h3>

Адрес: <code>http://localhost:5068/api/unit/list</code>


Тип метода: PUT

<table>
    <tr>Тело запроса:</tr>
    <tr>
        <td>Поле</td> <td>Описание</td>
    </tr>
    <tr>
        <td>classType (Обязательный)</td> <td>Класс юнита в enum</td>
    </tr>
</table>

Пример запроса:

http://localhost:5068/api/unit/list

Тело запроса:

    {
      "classType": 0
    }

Пример ответа:

    {
      "id": "ba170130-dd1f-4ecf-aca4-3efc39b7e858",
      "hp": 100,
      "maxHp": 100,
      "mana": 100,
      "maxMana": 100,
      "armor": 8,
      "magicResist": 6,
      "x": 75,
      "y": 79,
      "gameClass": {
        "classType": 0,
        "damageType": 0,
        "maxAttackRadius": 10,
        "damage": 10
      }
    }

<table>
    <tr>Параметры ответа:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id юнита</td>
    </tr>
    <tr>
        <td>hp</td> <td>Количество HP юнита (в процентах)</td>
    </tr>
    <tr>
        <td>maxHp</td> <td>Максимальное количество HP юнита (в процентах)</td>
    </tr>
    <tr>
        <td>mana</td> <td>Количество маны юнита (в процентах)</td>
    </tr>
    <tr>
        <td>maxMana</td> <td>Максимальное количество маны юнита (в процентах)</td>
    </tr>
    <tr>
        <td>armor</td> <td>Физическая броня юнита</td>
    </tr>
    <tr>
        <td>magicResist</td> <td>Магическая броня юнита</td>
    </tr>
    <tr>
        <td>x</td> <td>Положение юнита по оси X</td>
    </tr>
    <tr>
        <td>y</td> <td>Положение юнита по оси Y</td>
    </tr>
    <tr>
        <td>gameClass</td> <td>Структура класса юнита: <br> 
      classType - класс юнита в enum; <br> 
      damageType - тип урона юнита; <br>
      maxRadius - максимальная дальность атаки юнита; <br>
      damage - урон юнита</td>
    </tr>
</table>
<br></br>

<h3>4) Изменить юнита</h3>

Адрес: <code>http://localhost:5068/api/unit/edit</code>


Тип метода: POST

<table>
    <tr>Тело запроса:</tr>
    <tr>
        <td>Поле</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id (Обязательный)</td> <td>Id юнита</td>
    </tr>
    <tr>
        <td>classType (Обязательный)</td> <td>Класс юнита в enum</td>
    </tr>
</table>

Пример запроса:

http://localhost:5068/api/unit/edit

Тело запроса:

    {
      "id": "ba170130-dd1f-4ecf-aca4-3efc39b7e858",
      "classType": 1
    }

Пример ответа:

    {
      "id": "ba170130-dd1f-4ecf-aca4-3efc39b7e858",
      "hp": 100,
      "maxHp": 100,
      "mana": 100,
      "maxMana": 100,
      "armor": 8,
      "magicResist": 6,
      "x": 75,
      "y": 79,
      "gameClass": {
        "classType": 1,
        "damageType": 0,
        "maxAttackRadius": 350,
        "damage": 14
      }
    }

<table>
    <tr>Параметры ответа:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id юнита</td>
    </tr>
    <tr>
        <td>hp</td> <td>Количество HP юнита (в процентах)</td>
    </tr>
    <tr>
        <td>maxHp</td> <td>Максимальное количество HP юнита (в процентах)</td>
    </tr>
    <tr>
        <td>mana</td> <td>Количество маны юнита (в процентах)</td>
    </tr>
    <tr>
        <td>maxMana</td> <td>Максимальное количество маны юнита (в процентах)</td>
    </tr>
    <tr>
        <td>armor</td> <td>Физическая броня юнита</td>
    </tr>
    <tr>
        <td>magicResist</td> <td>Магическая броня юнита</td>
    </tr>
    <tr>
        <td>x</td> <td>Положение юнита по оси X</td>
    </tr>
    <tr>
        <td>y</td> <td>Положение юнита по оси Y</td>
    </tr>
    <tr>
        <td>gameClass</td> <td>Структура класса юнита: <br> 
      classType - класс юнита в enum; <br> 
      damageType - тип урона юнита; <br>
      maxRadius - максимальная дальность атаки юнита; <br>
      damage - урон юнита</td>
    </tr>
</table>
<br></br>

Изменения в базе данных:

Было:

    {
      "id": "ba170130-dd1f-4ecf-aca4-3efc39b7e858",
      "hp": 100,
      "maxHp": 100,
      "mana": 100,
      "maxMana": 100,
      "armor": 8,
      "magicResist": 6,
      "x": 75,
      "y": 79,
      "gameClass": {
        "classType": 0,
        "damageType": 0,
        "maxAttackRadius": 10,
        "damage": 10
      }
    }

Стало:

    {
      "id": "ba170130-dd1f-4ecf-aca4-3efc39b7e858",
      "hp": 100,
      "maxHp": 100,
      "mana": 100,
      "maxMana": 100,
      "armor": 8,
      "magicResist": 6,
      "x": 75,
      "y": 79,
      "gameClass": {
        "classType": 1,
        "damageType": 0,
        "maxAttackRadius": 350,
        "damage": 14
      }
    }

<br></br>

<h3>5) Атаковать юнита</h3>

Адрес: <code>http://localhost:5068/api/unit/attack</code>


Тип метода: POST

<table>
    <tr>Тело запроса:</tr>
    <tr>
        <td>Поле</td> <td>Описание</td>
    </tr>
    <tr>
        <td>sourceUnitId (Обязательный)</td> <td>Id атакующего юнита</td>
    </tr>
    <tr>
        <td>targetUnitId (Обязательный)</td> <td>Id атакуемого юнита</td>
    </tr>
</table>

Пример запроса:

http://localhost:5068/api/unit/attack

Тело запроса:

    {
      "sourceUnitId": "0da5b9d3-bc6a-4907-990d-3c6e0ef07f50",
      "targetUnitId": "d28ef645-9e1c-48bc-92da-b374d372c947"
    }

Пример ответа:

    {
      "sourceUnit": {
        "id": "0da5b9d3-bc6a-4907-990d-3c6e0ef07f50",
        "hp": 100,
        "maxHp": 100,
        "mana": 100,
        "maxMana": 100,
        "armor": 6,
        "magicResist": 6,
        "x": 93,
        "y": 89,
        "gameClass": {
          "classType": 1,
          "damageType": 0,
          "maxAttackRadius": 350,
          "damage": 11
        }
      },
      "targetUnit": {
        "id": "d28ef645-9e1c-48bc-92da-b374d372c947",
        "hp": 97,
        "maxHp": 100,
        "mana": 100,
        "maxMana": 100,
        "armor": 9,
        "magicResist": 6,
        "x": 95,
        "y": 81,
        "gameClass": {
          "classType": 0,
          "damageType": 0,
          "maxAttackRadius": 10,
          "damage": 17
        }
      },
      "damage": 3,
      "description": null,
      "result": 0
    }

<table>
    <tr>Параметры ответа:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>sourceUnit</td> <td>Информация об атакующем юните</td>
    </tr>
    <tr>
        <td>targetUnit</td> <td>Информация об атакуемом юните</td>
    </tr>
    <tr>
        <td>damage</td> <td>Количество нанесенного урона</td>
    </tr>
    <tr>
        <td>description</td> <td>Описание результата</td>
    </tr>
    <tr>
        <td>result</td> <td>enum результат операции</td>
    </tr>
</table>
<br></br>

<h3>6) Удалить юнита</h3>

Адрес: <code>http://localhost:5068/api/unit/remove</code>


Тип метода: DELETE

<table>
    <tr>Параметры запроса:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id юнита</td>
    </tr>
</table>

Пример запроса:

http://localhost:5068/api/unit/remove?id=ba170130-dd1f-4ecf-aca4-3efc39b7e858

Пример ответа:

    {
      "id": "ba170130-dd1f-4ecf-aca4-3efc39b7e858",
      "hp": 100,
      "maxHp": 100,
      "mana": 100,
      "maxMana": 100,
      "armor": 8,
      "magicResist": 6,
      "x": 75,
      "y": 79,
      "gameClass": {
        "classType": 1,
        "damageType": 0,
        "maxAttackRadius": 350,
        "damage": 6
      }
    }

<table>
    <tr>Параметры ответа:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id юнита</td>
    </tr>
    <tr>
        <td>hp</td> <td>Количество HP юнита (в процентах)</td>
    </tr>
    <tr>
        <td>maxHp</td> <td>Максимальное количество HP юнита (в процентах)</td>
    </tr>
    <tr>
        <td>mana</td> <td>Количество маны юнита (в процентах)</td>
    </tr>
    <tr>
        <td>maxMana</td> <td>Максимальное количество маны юнита (в процентах)</td>
    </tr>
    <tr>
        <td>armor</td> <td>Физическая броня юнита</td>
    </tr>
    <tr>
        <td>magicResist</td> <td>Магическая броня юнита</td>
    </tr>
    <tr>
        <td>x</td> <td>Положение юнита по оси X</td>
    </tr>
    <tr>
        <td>y</td> <td>Положение юнита по оси Y</td>
    </tr>
    <tr>
        <td>gameClass</td> <td>Структура класса юнита: <br> 
      classType - класс юнита в enum; <br> 
      damageType - тип урона юнита; <br>
      maxRadius - максимальная дальность атаки юнита; <br>
      damage - урон юнита</td>
    </tr>
</table>
<br></br>

<h2>Schemas</h2>

1) classType (enum)

<table>
    <tr>
        <td>Значение</td> <td>Название</td>
    </tr>
    <tr>
        <td>0</td> <td>Warrior</td>
    </tr>
    <tr>
        <td>1</td> <td>Ranger</td>
    </tr>
    <tr>
        <td>2</td> <td>Mage</td>
    </tr>
</table>

2) damageType (enum)

<table>
    <tr>
        <td>Значение</td> <td>Название</td>
    </tr>
    <tr>
        <td>0</td> <td>Phisycal</td>
    </tr>
    <tr>
        <td>1</td> <td>Magical</td>
    </tr>
</table>

3) result (enum)

<table>
    <tr>
        <td>Значение</td> <td>Название</td>
    </tr>
    <tr>
        <td>0</td> <td>Attacked</td>
    </tr>
    <tr>
        <td>1</td> <td>OutOfRange</td>
    </tr>
    <tr>
        <td>2</td> <td>Error</td>
    </tr>
</table>
