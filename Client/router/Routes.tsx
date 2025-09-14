import { createBrowserRouter } from "react-router-dom";
import App from "../src/components/App";
import HomePage from "../src/pages/HomePage";
import AboutPage from "../src/pages/AboutPage";
import ContactPage from "../src/pages/ContactPage";
import CatalogPage from "../src/pages/catalog/CatalogPage";
import ProductDetailsPage from "../src/pages/catalog/ProductDetails";
import ErrorPage from "../src/pages/ErrorPage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children:[
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
            }
        ]
    }
])