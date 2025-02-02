import { createRootRoute, Link, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";

export const Route = createRootRoute({
  component: () => (
    <>
      <div className="flex gap-2 p-2">
        <Link to="/" className="[&.active]:font-bold">
          Home
        </Link>{" "}
        <Link to="/statistics/StatisticsRoute" className="[&.active]:font-bold">
          statistics
        </Link>
        <Link
          to="/wishlists/WishListRoute"
          search={{
            q: "WishList",
          }}
          className="[&.active]:font-bold"
        >
          Wishlist
        </Link>
      </div>
      <hr />
      <Outlet />
      <TanStackRouterDevtools />
    </>
  ),
});
