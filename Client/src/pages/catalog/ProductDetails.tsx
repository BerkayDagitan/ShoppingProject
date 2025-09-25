import { CircularProgress, Divider, Grid, Stack, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import type { IProduct } from "../../model/IProduct";
import request from "../../api/request";
import { LoadingButton } from "@mui/lab";
import { AddShoppingCart } from "@mui/icons-material";
import { toast } from "react-toastify";
import { currencyTRY } from "../../utils/formatCurrency";
import { useAppDispatch, useAppSelector } from "../../hooks/hooks";
import { setCart } from "../cart/cartSlice";

export default function ProductDetailsPage() {

    const { cart } = useAppSelector(state => state.cart);
    const dispatch = useAppDispatch();

    const{id} = useParams<{id: string}>();
    const [product, setProduct] = useState<IProduct | null>(null);
    const [loading, setLoading] = useState(true);
    const [isAdded, setIsAdded] = useState(false);

    const item = cart?.cartItems.find(i => i.productId == product?.id);

    useEffect(() => {
        request.Catalog.details(parseInt(id!))
        .then(data => setProduct(data))
        .catch(error => console.log(error))
        .finally(() => setLoading(false));
    },[id]);

    function handleAddItem(id: number){
        setIsAdded(true);
        request.Cart.addItem(id)
        .then(cart => {
            dispatch(setCart(cart))
            toast.success("Item added to cart");
        })
        .catch(error => console.log(error))
        .finally(() => setIsAdded(false));
    }

    if(loading) return <CircularProgress />;
    if(!product) return <h5>Product not found</h5>

    return(
        <Grid container spacing={6}>
            <Grid size={{lg: 4, md: 5, sm: 6, xs: 12}}>
                <img src={`http://localhost:5239/images/${product.imageUrl}`} alt={product.name} style={{width: '100%'}} />
            </Grid>
            <Grid size={{lg: 8, md: 7, sm: 6, xs: 12}}>
                <Typography variant="h3">{product.name}</Typography>
                <Divider sx={{mb:2}} />
                <Typography variant="h4" color="secondary">{currencyTRY.format(product.price)}</Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Product Name</TableCell>
                                <TableCell>{product.name}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Description</TableCell>
                                <TableCell>{product.description}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Stock</TableCell>
                                <TableCell>{product.stock}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
                <Stack direction="row" sx={{mt:3}} alignItems={"center"} spacing={4}>
                    <LoadingButton variant="outlined" loadingPosition="start" startIcon={<AddShoppingCart />} loading={isAdded} onClick={() =>handleAddItem(product.id)}>
                        Add to Cart
                    </LoadingButton>
                    {
                        item?.quantity! > 0 && (
                            <Typography variant="body2">In Cart: {item?.quantity}</Typography>
                        )
                    }
                </Stack>
            </Grid>
        </Grid>
    );
}