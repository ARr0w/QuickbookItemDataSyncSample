# QuickBooks Integration Console Application  

## Overview  
This console application integrates with QuickBooks to retrieve inventory data daily. It uses OAuth2 authentication, requiring manual retrieval of an authorization code to exchange for an access token and refresh token.  

---

## 📌 How It Works  

### 🔹 Step 1: Obtain QuickBooks API Credentials  
Before integrating with QuickBooks, you must create an app in the **QuickBooks Developer Portal** to get the required credentials.  

#### Steps to Get `Client ID` and `Client Secret`:  
1. **Go to QuickBooks Developer Portal** → [QuickBooks Developer Dashboard](https://developer.intuit.com/)  
2. **Log in or Sign up**  
3. **Create an App** under **My Apps**  
4. **Select QuickBooks Online & Payments** as the platform  
5. Navigate to the **Keys & OAuth** section  
6. Copy your **Client ID** and **Client Secret**  

> ⚠️ Keep these credentials secure and do not share them.  

---

### 🔹 Step 2: Configure the Application  

#### 1️⃣ **Set `Client ID` and `Client Secret` in Code**  
Modify the `AuthService` class in the source code to include your credentials:  

```csharp
public class AuthService
{
    private readonly string clientId = "<YOUR_CLIENT_ID>";
    private readonly string clientSecret = "<YOUR_CLIENT_SECRET>";

    // Other authentication logic...
}


### 🔹 Step 3: Configure the Application  
Before running the application, update the `appsettings.json` file:  

```json
{
  "CompanyId": "<YOUR_COMPANY_ID>",
  "Code": "<YOUR_AUTHORIZATION_CODE>"
}
