# Simple Bank API Demo

This project demonstrates a basic API integration flow where a client sends a JSON request to an API and receives a JSON response.

---

## Overview

This demo simulates how a client application interacts with a backend API.

Flow:

Client → JSON request → API → validation → data retrieval → JSON response

---

## API Endpoint

**POST** `/api/account/balance`

---

## Client Usage

A client sends a JSON request to the API.

### Example Request

```bash
curl -X POST http://localhost:5000/api/account/balance \
-H "Content-Type: application/json" \
-d '{"accountId":"A1001"}'