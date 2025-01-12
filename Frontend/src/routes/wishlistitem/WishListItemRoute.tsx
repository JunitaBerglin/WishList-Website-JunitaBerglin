import { createFileRoute } from "@tanstack/react-router";
import { WishCard } from "../../components/WishCard";

export const Route = createFileRoute("/wishlistitem/WishListItemRoute")({
  component: WishCard,
});
