import { Button, Container } from "@mui/material";
import request from "../api/request";

export default function ErrorPage(){
    return(
        <Container>
            <Button sx={{ mt: 2 }} variant="contained" onClick={() => request.Errors.get400error().catch(error => console.log(error))}>400 Error</Button>
            <Button sx={{ mt: 2 }} variant="contained" onClick={() => request.Errors.get401error().catch(error => console.log(error))}>401 Error</Button>
            <Button sx={{ mt: 2 }} variant="contained" onClick={() => request.Errors.get404error().catch(error => console.log(error))}>404 Error</Button>
            <Button sx={{ mt: 2 }} variant="contained" onClick={() => request.Errors.get500error().catch(error => console.log(error))}>500 Error</Button>
            <Button sx={{ mt: 2 }} variant="contained" onClick={() => request.Errors.getValidationError().catch(error => console.log(error))}>Validation Error</Button>
        </Container>
    );
}