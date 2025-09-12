import { createBrowserRouter } from "react-router-dom";
import App from "../src/components/App";
import HomePage from "../src/pages/HomePage";
import AboutPage from "../src/pages/AboutPage";
import ContactPage from "../src/pages/ContactPage";

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
            }
        ]
    }
])