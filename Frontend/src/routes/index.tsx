import { createRouter, createRouteTree } from "@tanstack/react-router";
import { WishListRoute } from "./WishListRoute";
import { StatisticsRoute } from "./StatisticsRoute";

const routeTree = createRouteTree([
  RootRoute.addChildren([WishListRoute, StatisticsRoute]),
]);

export const router = createRouter({ routeTree });
