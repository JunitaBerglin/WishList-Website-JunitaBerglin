import { createLazyFileRoute } from "@tanstack/react-router";
import { WishCard } from "../../components/WishCard";

export const Route = createLazyFileRoute("/wishlistitem/wishlistitem")({
  component: WishCard,
});
