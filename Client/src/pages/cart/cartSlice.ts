import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import type { Cart } from "../../model/ICart.ts";
import request from "../../api/request.ts";
import { toast } from "react-toastify";

interface CartState {
    cart: Cart | null;
    status : string;
}

const initialState: CartState = {
    cart : null,
    status: "idle"
}

export const addItemToCart = createAsyncThunk<Cart, {productId: number, quantity?: number}>(
    "cart/addItemToCart",
    async ({productId, quantity = 1}) => {
        try
        {
            return await request.Cart.addItem(productId, quantity);
        }
        catch (error)
        {
            console.log(error);
        }
    }
);

export const deleteItemFromCart = createAsyncThunk<Cart, {productId: number, quantity?: number, key?: string}>(
    "cart/deleteItemFromCart",
    async ({productId, quantity = 1}) => {
        try
        {
            return await request.Cart.deleteItem(productId, quantity);
        }
        catch (error)
        {
            console.log(error);
        }
    }
);

export const cartSlice = createSlice({
    name : "cart",
    initialState,
    reducers : {
        setCart: (state, action) => {
            state.cart = action.payload;
        }
    },
    extraReducers: (builder) => {
        builder.addCase(addItemToCart.pending, (state, action) => {
            console.log(action);
            state.status = "pendingAddItem" + action.meta.arg.productId;
        });
        builder.addCase(addItemToCart.fulfilled, (state, action) => {
            console.log(action);
            state.cart = action.payload;
            state.status = "idle";
            toast.success("The product was added to the cart.");
        });
        builder.addCase(addItemToCart.rejected, (state) => {
            state.status = "idle";
        });
        builder.addCase(deleteItemFromCart.pending, (state, action) => {
            console.log(action);
            state.status = "pendingDeleteItem" + action.meta.arg.productId + action.meta.arg.key;
        });
        builder.addCase(deleteItemFromCart.fulfilled, (state, action) => {
            state.cart = action.payload;
            state.status = "idle";
            toast.error("The product was removed from the cart.");
        });
        builder.addCase(deleteItemFromCart.rejected, (state) => {
            state.status = "idle";
        });
    }
})

export const { setCart } = cartSlice.actions;