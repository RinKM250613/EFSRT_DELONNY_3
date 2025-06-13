import React from 'react';
import { motion } from 'framer-motion';
import { ShoppingCart, Menu, Search } from 'lucide-react';

const Header = ({ cartItemsCount, onCartClick }) => {
    return (
        <motion.header
            initial={{ y: -80, opacity: 0 }}
            animate={{ y: 0, opacity: 1 }}
            transition={{ duration: 0.6 }}
            className="fixed-top bg-white bg-opacity-90 border-bottom shadow"
            style={{ backdropFilter: 'blur(10px)', zIndex: 1050 }}
        >
            <div className="container-fluid px-4">
                <div className="d-flex align-items-center justify-content-between py-2">
                    {/* Logo */}
                    <motion.div whileHover={{ scale: 1.05 }} className="fs-4 fw-bold text-orange">
                        Delonny's
                    </motion.div>

                    {/* Navigation */}
                    <nav className="d-none d-md-flex gap-4">
                        <a href="#home" className="text-dark text-decoration-none hover-orange">Home</a>
                        <a href="#categories" className="text-dark text-decoration-none hover-orange">Categories</a>
                        <a href="#about" className="text-dark text-decoration-none hover-orange">About</a>
                        <a href="#services" className="text-dark text-decoration-none hover-orange">Services</a>
                    </nav>

                    {/* Right side actions */}
                    <div className="d-flex align-items-center gap-3">
                        <motion.button
                            whileHover={{ scale: 1.05 }}
                            whileTap={{ scale: 0.95 }}
                            className="btn btn-link text-dark p-0"
                        >
                            <Search size={20} />
                        </motion.button>

                        <motion.button
                            whileHover={{ scale: 1.05 }}
                            whileTap={{ scale: 0.95 }}
                            onClick={onCartClick}
                            className="btn btn-link text-dark position-relative p-0"
                        >
                            <ShoppingCart size={20} />
                            {cartItemsCount > 0 && (
                                <motion.span
                                    initial={{ scale: 0 }}
                                    animate={{ scale: 1 }}
                                    className="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-orange"
                                    style={{ fontSize: '0.7rem', width: '1.25rem', height: '1.25rem', display: 'flex', alignItems: 'center', justifyContent: 'center' }}
                                >
                                    {cartItemsCount}
                                </motion.span>
                            )}
                        </motion.button>

                        <motion.button
                            whileHover={{ scale: 1.05 }}
                            whileTap={{ scale: 0.95 }}
                            className="d-md-none btn btn-link text-dark p-0"
                        >
                            <Menu size={20} />
                        </motion.button>
                    </div>
                </div>
            </div>
        </motion.header>
    );
};

export default Header;
