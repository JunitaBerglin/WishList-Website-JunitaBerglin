import React from "react";

interface CardProps {
  name: string;
  description: string;
  price: number;
  imageUrl: string;
  onReadMore: () => void;
  onPurchase: () => void;
}

const WishCard: React.FC<CardProps> = ({
  name,
  description,
  price,
  imageUrl,
  onReadMore,
  onPurchase,
}) => {
  return (
    <div className="flex flex-col">
      <div className="relative">
        <img className="hidden lg:block" src={imageUrl} alt={name} />
        <img className="hidden sm:block lg:hidden" src={imageUrl} alt={name} />
        <img className="sm:hidden" src={imageUrl} alt={name} />
      </div>
      <div className="mt-6 flex justify-between items-center">
        <div className="flex justify-center items-center">
          <p className="tracking-tight text-2xl font-semibold leading-6 text-gray-800 dark:text-white">
            {name}
          </p>
        </div>
      </div>
      <div className="flex flex-col justify-start items-start mt-4">
        <p className="tracking-tight text-base font-medium leading-4 text-gray-800 dark:text-white">
          {description}
        </p>
        <p className="tracking-tight text-base font-medium leading-4 text-gray-800 dark:text-white mt-4">
          ${price}
        </p>
      </div>
      <div className="flex justify-between items-center mt-6 space-x-4">
        <button
          onClick={onReadMore}
          className="focus:outline-none focus:ring-gray-800 focus:ring-offset-2 focus:ring-2 text-gray-800 text-white w-full tracking-tight py-4 text-lg leading-4 hover:bg-gray-300 hover:text-gray-800 dark:bg-transparent dark:border-white dark:hover:bg-gray-800 bg-white border border-gray-800 dark:hover:text-white"
        >
          Read More
        </button>
        <button
          onClick={onPurchase}
          className="focus:outline-none focus:ring-gray-800 focus:ring-offset-2 focus:ring-2 text-white w-full tracking-tight py-4 text-lg leading-4 hover:bg-black bg-gray-800 border border-gray-800 dark:hover:bg-gray-700 dark:hover:text-white"
        >
          Purchase
        </button>
      </div>
    </div>
  );
};

export { WishCard };
