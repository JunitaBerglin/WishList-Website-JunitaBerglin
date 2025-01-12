import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/wishlists/$wishlistid')({
  component: RouteComponent,
  loader: async ({ params }: { params: { wishListId: string } }) => {
    await new Promise((resolve) => setTimeout(resolve, 1000))
    return {
      wishListId: params.wishListId,
    }
  },
  pendingComponent: () => <div>Loading...</div>,
  errorComponent: () => <div>Error</div>,
})

function RouteComponent() {
  const { wishListId } = Route.useLoaderData()

  return <div>This is {wishListId}!</div>
}
