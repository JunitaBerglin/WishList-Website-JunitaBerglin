import { RouterProvider } from "@tanstack/react-router";
import { router } from "./routes";

export default function App() {
  return (
    <RouterProvider router={router}>
      <div className="text-center p-10">
        <h1 className="text-3xl font-bold text-blue-600">
          Welcome to Wish List Website
        </h1>
      </div>
    </RouterProvider>
  );
}
