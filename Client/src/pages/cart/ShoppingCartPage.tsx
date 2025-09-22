import { useEffect, useState } from "react"
import request from "../../api/request"
import { CircularProgress, IconButton, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import type { Cart } from "../../model/ICart.ts";
import { Delete } from "@mui/icons-material";

export default function ShoppingCartPage()
{
    const [cart, setCart] = useState<Cart | null>(null);
    const [loading , setLoading] = useState(true);

    useEffect(()=> {

        request.Cart.get()
        .then(cart => setCart(cart))
        .catch(error => console.log(error))
        .finally(()=> setLoading(false))

    }, [])

    if(loading) return <CircularProgress />
    if(!cart) return <h1>There are no items in your cart</h1>

    return (
        <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Product</TableCell>
            <TableCell align="right">Prices</TableCell>
            <TableCell align="right">Quantity</TableCell>
            <TableCell align="right">Total Prices</TableCell>
            <TableCell align="right"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {cart.cartItems.map((item) => (
            <TableRow
              key={item.productId}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
                <TableCell component="th" scope="row">
                <img src={`http://localhost:5239/images/${item.imageUrl}`} style={{height: 60}} />
              </TableCell>
              <TableCell component="th" scope="row">
                {item.name}
              </TableCell>
              <TableCell align="right">{item.price} ₺</TableCell>
              <TableCell align="right">{item.quantity}</TableCell>
              <TableCell align="right">{item.price * item.quantity}</TableCell>
              <TableCell align="right">
                <IconButton color="error">
                    <Delete />
                </IconButton>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    );
}