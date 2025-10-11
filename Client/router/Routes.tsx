import { createBrowserRouter, Navigate } from "react-router-dom";
import App from "../src/components/App";
import HomePage from "../src/features/counter/HomePage";
import AboutPage from "../src/features/counter/AboutPage";
import ContactPage from "../src/features/counter/ContactPage";
import CatalogPage from "../src/features/catalog/CatalogPage";
import ProductDetailsPage from "../src/features/catalog/ProductDetails";
import ErrorPage from "../src/features/counter/ErrorPage";
import ServerError from "../src/errors/ServerError";
import NotFound from "../src/errors/NotFound";
import ShoppingCartPage from "../src/features/cart/ShoppingCartPage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "", element: <HomePage />
            },
            {
                path: "about", element: <AboutPage />
            },
            {
                path: "contact", element: <ContactPage />
            },
            {
                path: "catalog", element: <CatalogPage />
            },
            {
                path: "catalog/:id", element: <ProductDetailsPage />
            },
            {
                path: "error", element: <ErrorPage />
            },
            {
                path: "server-error", element: <ServerError />
            },
            {
                path: "not-found", element: <NotFound />
            },
            {
                path: "cart", element: <ShoppingCartPage />
            },
            {
                path: "*", element: <Navigate to="/not-found" replace />
            }
        ]
    }
])