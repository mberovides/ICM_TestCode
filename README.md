# ICM_TestCode
Code Test for International Market Centers

Tax calculation. Use a Tax calculation API’s via a common interface we define in a service class.

The code test is to simply create a Tax Service that can take a Tax Calculator in the class initialization and return the total tax that needs to be collected.

Using Tax Jar as one of our calculators.

This are two test cases to test:

We implemented a geo location seerrvices to avoid the user enter more information and only needs to know the zip,

For that reason there test case example.

Zip locations: "07001", "90404", "07001", "07446","33024", "33027"

Order To Tax: { "zipCodeFrom": "07001", "zipCodeTo": "07446", "amount": 16.50, "shipping": 1.5, "lineItems": [ { "quantity": 1, "unitPrice": 15.0, "productTaxCode": "31000" } ] }
