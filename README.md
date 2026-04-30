# Simple Bank API Demo

This project demonstrates a basic API integration flow using JSON request and response.

## Overview

The API receives an accountId from the client, validates the request, retrieves account data, and returns a JSON response.

This project was created to understand API integration concepts such as:
- JSON request and response
- Input validation
- HTTP status codes
- Basic data mapping

## API Endpoint

POST /api/account/balance

## Sample Request

```json
{
  "accountId": "A1001"
}
