import { createBrowserRouter } from "react-router-dom";
import App from "../src/components/App";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
    }

])