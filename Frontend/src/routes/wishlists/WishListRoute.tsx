import { createFileRoute } from "@tanstack/react-router";
import { wishList } from "../../components/pages/WishList";

export const Route = createFileRoute("/wishlists/WishListRoute")({
  component: wishList,
});
