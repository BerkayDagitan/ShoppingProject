import { Button, Card, Container, Divider, Typography } from "@mui/material";
import { NavLink } from "react-router-dom";

export default function NotFound(){
    return (
        <Container component={Card} sx={{p: 3}}>
            <Typography variant="h5" gutterBottom>Page Not Found</Typography>
            <Divider/>
            <Button variant="contained" color="primary" component={NavLink} to="/catalog" sx={{mt: 3}}> Continue Shopping</Button>
        </Container>
    );
}