# Domain Model

## Menu

```csharp
    class Menu
    {
        Menu Create();
        void AddDinner(Dinner dinner);
        void RemoveDinner(Dinner dinner);
        void AddSection(MenuSection section);
    }

```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "hostId": "00000000-0000-0000-0000-000000000000",
    "name": "Yummy Menu",
    "description": "This is a yummy menu",
    "averageRating": 5.0,
    "sections": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "name": "Appetizers",
            "description": "Yummy appetizers",
            "items": [
                {
                    "id": "00000000-0000-0000-0000-000000000000",
                    "name": "Yummy Appetizer",
                    "description": "This is a yummy appetizer",
                    "price": 10.0,
                    "isAvailable": true
                }
            ]
        }
    ],
    "createdDateTime": "2021-01-01T00:00:00",
    "updatedDateTime": "2021-01-01T00:00:00",
    "dinnerIds": [
        "00000000-0000-0000-0000-000000000000"
    ],
    "menuReviewIds": [
        "00000000-0000-0000-0000-000000000000"
    ],
}
```
