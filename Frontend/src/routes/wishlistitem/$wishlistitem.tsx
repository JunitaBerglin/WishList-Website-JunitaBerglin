import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/wishlistitem/$wishlistitem")({
  component: RouteComponent,
  loader: async ({ params }: { params: { wishListItemId: string } }) => {
    await new Promise((resolve) => setTimeout(resolve, 1000));
    return {
      wishListItemId: params.wishListItemId,
    };
  },
  pendingComponent: () => <div>Loading...</div>,
  errorComponent: () => <div>Error</div>,
});

function RouteComponent() {
  const { wishListItemId } = Route.useLoaderData();

  return <div>This is {wishListItemId}!</div>;
}
