import { createFileRoute, Link } from "@tanstack/react-router";

export const Route = createFileRoute("/wishlists/")({
  component: Wishlists,
  validateSearch: (search) => {
    return {
      q: (search.q as string) || "",
    };
  },
  loaderDeps: ({ search: { q } }) => ({ q }),
  loader: async ({ deps: { q } }) => {
    const wishlists = ["wishlist1", "wishlist2", "wishlist3"];
    return {
      wishlists: wishlists.filter((wishlist) => wishlist.includes(q)),
    };
  },
});

function Wishlists() {
  const { wishlists } = Route.useLoaderData();
  const { q } = Route.useSearch();

  return (
    <div>
      <input
        type="text"
        value={q}
        // onChange={(e) => Route.to({ search: { q: e.target.value } })}
        placeholder="Search wishlists"
      />
      {wishlists.map((wishlist) => (
        <div key={wishlist}>
          <Link
            to="/wishlists/$wishlistid"
            params={{
              wishListId: wishlist,
            }}
          >
            {wishlist}
          </Link>
        </div>
      ))}
    </div>
  );
}
