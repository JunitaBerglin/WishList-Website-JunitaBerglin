import { createLazyFileRoute } from '@tanstack/react-router'
import { wishList } from '../../components/pages/WishList'

export const Route = createLazyFileRoute('/wishlists/wishlist')({
  component: wishList,
})
