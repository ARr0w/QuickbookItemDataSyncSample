# QuickBooks Integration Console Application  

## Overview  
This console application integrates with QuickBooks to retrieve inventory data daily. It uses OAuth2 authentication, requiring manual retrieval of an authorization code to exchange for an access token and refresh token.  

---

## 📌 How It Works  

### 🔹 Step 1: Obtain the Authorization Code  
1. **Log in to QuickBooks Developer Portal**  
   - Open the QuickBooks OAuth Authorization URL.  
   - Log in using your QuickBooks account.  

2. **Select the Company**  
   - Choose the **Company ID** associated with QuickBooks.  

3. **Authorize the Application**  
   - Grant access permission to retrieve inventory data.  

4. **Copy the Authorization Code**  
   - After successful authorization, QuickBooks will provide an **authorization code**.  
   - Copy this code for use in the next step.  

---

### 🔹 Step 2: Configure the Application  
Before running the application, update the `appsettings.json` file:  

```json
{
  "CompanyId": "<YOUR_COMPANY_ID>",
  "Code": "<YOUR_AUTHORIZATION_CODE>"
}
