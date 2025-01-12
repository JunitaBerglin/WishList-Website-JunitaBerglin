import { WishCard } from "../WishCard";

export const mockItems = [
  {
    id: 1,
    name: "New York Streak",
    description: "Beige brown, 42 size",
    price: 1000,
    imageUrl: "https://i.ibb.co/SsmkhPq/Rectangle-23.png",
  },
  {
    id: 2,
    name: "Luxe 3 series",
    description: "Modern watch with sleek design",
    price: 500,
    imageUrl: "https://i.ibb.co/WVySXBL/Rectangle-24.png",
  },
  {
    id: 3,
    name: "EZ sneakers",
    description: "Comfortable sneakers, 42 size",
    price: 150,
    imageUrl: "https://i.ibb.co/JqD4MwR/Rectangle-5.png",
  },
];

const wishList = () => {
  const handleReadMore = (id: number) => {
    console.log("Read more clicked for item:", id);
    // <Link to={`/wishListItem/${id}`} />;
  };

  const handlePurchase = (id: number) => {
    console.log("Purchase clicked for item:", id);
  };

  return (
    <div className="mx-auto container px-4 md:px-6 2xl:px-0 py-12 flex justify-center items-center">
      <div className="grid grid-cols-1 lg:grid-cols-3 gap-x-8 gap-y-10 lg:gap-y-0">
        {mockItems.map((item) => (
          <WishCard
            key={item.id}
            name={item.name}
            description={item.description}
            price={item.price}
            imageUrl={item.imageUrl}
            onReadMore={() => handleReadMore(item.id)}
            onPurchase={() => handlePurchase(item.id)}
          />
        ))}
      </div>
    </div>
  );
};

export { wishList };
