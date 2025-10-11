import { Alert, AlertTitle, Button, Container, List, ListItem, ListItemText } from "@mui/material";
import request from "../../api/request";
import { useState } from "react";

export default function ErrorPage() {
    const [validationErrors, setValidationErrors] = useState<string[]>([]);

    function getValidationErrors() {
        request.Errors.getValidationError()
            .then(() => console.log("no validation"))
            .catch(errors => setValidationErrors(errors));
    }

    return (
        <Container>
            {
                validationErrors.length > 0 &&
                (
                    <Alert severity="error" sx={{ mt: 2 }}>
                        <AlertTitle>Validation Errors</AlertTitle>
                        <List>
                            {
                                validationErrors.map((error, index) => (
                                    <ListItem key={index}>
                                        <ListItemText>
                                            {error}
                                        </ListItemText>
                                    </ListItem>
                                ))
                            }
                        </List>
                    </Alert>
                )
            }
            <Button sx={{ mt: 2 }} variant="contained" onClick={() => request.Errors.get400error().catch(error => console.log(error))}>400 Error</Button>
            <Button sx={{ mt: 2 }} variant="contained" onClick={() => request.Errors.get401error().catch(error => console.log(error))}>401 Error</Button>
            <Button sx={{ mt: 2 }} variant="contained" onClick={() => request.Errors.get404error().catch(error => console.log(error))}>404 Error</Button>
            <Button sx={{ mt: 2 }} variant="contained" onClick={() => request.Errors.get500error().catch(error => console.log(error))}>500 Error</Button>
            <Button sx={{ mt: 2 }} variant="contained" onClick={getValidationErrors}>Validation Error</Button>
        </Container>
    );
}