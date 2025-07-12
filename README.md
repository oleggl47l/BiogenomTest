# BiogenomTest
# BiogenomTest API

## О проекте

Тестовой задание: реализовать без Minimal API и top-level statements Web API проект, который бы предоставлял API
для реализации запросов для такой страницы. Данные должны браться из PostgreSQL через EF
Core. Если есть непонимание где как лучше сделать и почему, сделайте на своё усмотрение.

Основные возможности API:
- Получение текущего суточного потребления нутриентов
- Получение персональных наборов
- Получение нового суточного потребления с учетом набора
- Получение преимуществ

---

## Технологии

- ASP.NET Core Web API
- MediatR (CQRS)
- Entity Framework Core (PostgreSQL)
- Serilog (логирование)
- Docker

---

## Запуск проекта

### Требования

- Docker Desktop

### Шаги запуска

1. Клонируйте репозиторий

    ```bash
    git clone https://github.com/oleggl47l/BiogenomTest.git
    ```

2. Запустите сервисы командой в корне репозитория:

    ```bash
    docker compose up --build -d
    ```

3. После успешного запуска API будет доступно по адресу:  
   `http://localhost:5031/api/v1/IndividualReport`

---



## Примеры запросов

- Получить все нутриенты по текущему суточному потреблению:

    ```
    GET http://localhost:5031/api/v1/IndividualReport/daily-intake
    ```

- Получить нутриенты, которых не хватает (статус Low):

    ```
    GET http://localhost:5031/api/v1/IndividualReport/daily-intake?Status=Low
    ```

- Получить нутриенты в достаточном количестве (статус Normal):

    ```
    GET http://localhost:5031/api/v1/IndividualReport/daily-intake?Status=Normal
    ```

- Получить новый прогноз суточного потребления с учетом персонализированного набора:

    ```
    GET http://localhost:5031/api/v1/IndividualReport/intake-projection
    ```

- Получить преимущества приема БАДов:

    ```
    GET http://localhost:5031/api/v1/IndividualReport/supplement-benefits
    ```

- Получить персонализированные наборы БАДов:

    ```
    GET http://localhost:5031/api/v1/IndividualReport/supplement-products
    ```

---
## ERD
<img width="472" height="594" alt="image" src="https://github.com/user-attachments/assets/96c5d433-1fb3-40e4-bcee-5b7b9f5fc639" />
