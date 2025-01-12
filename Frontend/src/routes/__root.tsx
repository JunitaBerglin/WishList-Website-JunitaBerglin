import { Link, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";

export const RootRoute = () => (
  <>
    <div className="p-2 flex gap-2">
      <Link
        to="/"
        activeProps={{
          className: "font-bold",
        }}
        activeOptions={{ exact: true }}
      >
        Home
      </Link>
      <Link to="/WishListPage">Wish List</Link>
      <Link to="/StatisticsPage">Statistics</Link>
    </div>
    <Outlet />
    <TanStackRouterDevtools />
  </>
);
