# Wishlist website Assignment

Tech stack: [ASP.NET](http://asp.net/), Entity Framework, MS SQL Server, React, Tanstack Router, TypeScript.

## Project planning: https://github.com/users/JunitaBerglin/projects/6/views/2

1. **User Wish Lists**:
   - Users can add, edit, or delete items from their own wish list.
   - Items in a wish list include a name, optional description, price, and optional link to the item online.
2. **Viewing and Interacting with Wish Lists**:
   - Users can view wish lists created by others.
   - Users can purchase items on another user’s wish list.
   - Purchased items will be displayed on the users public list as purchased
   - Purchased items should be hidden from the list creator's private list but show up in a private history list
3. **Shopping Cart:**
4. - Items being purchased are added to a shopping cart that keeps track of items via Local Storage.
   - Going to the shopping cart page and buying the items use no real money but instead just updates the status of the items
5. **Authentication**:
   - A flag in the URL will be used to simulate a user being logged in.
     - Not logged in: [https://example.com/UserName](https://example.com/UserName)
     - Logged in: [https://example.com/UserName?loggedin](https://example.com/UserName?loggedin)
   - If the flag is not used, the website assumes the logged in user is **TestUser**
6. **Statistics Page**:
   - A page showing aggregated statistics for all users, including:
     - Total number of items added by each user.
     - Total number of items purchased by each user for others.
   - Total number of users.

**Example Scenarios:**

1. **Adding Items**: Alice adds a wish list item: "Noise-cancelling headphones, $250, [Amazon link](https://amazon.com/)."
2. **Purchasing Gifts**: Bob views Alice's wish list and buys them
   - Alice can no longer see the headphones in her wish list. But instead it's now moved to the history list
   - Other users, including Bob, can still see that the item has been purchased.
3. **Statistics Page**: Displays:
   - Total items added by Alice: 5
   - Total items purchased by Bob: 3
   - Total users: 10
