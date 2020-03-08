import React, { Component } from 'react';
import Logo from '../assets/logo.jpg';

class Welcome extends Component {
    constructor(props) {
        super(props);
        this.state = {

        };
    }

    render() {
        return (
            <div>
                <div className="sticky-top text-center pt-4" style={{ width: '100%', height: 100, backgroundColor: 'white' }}>
                    <img alt="logo triunfo" src={Logo} />
                </div>
                <div className="container text-center mt-4">
                    <div className="my-5">
                        <h1>HISTÓRIAS CONECTADAS MUDAM HISTÓRIAS</h1>
                    </div>
                    <hr />
                    <p className="my-5 px-5" >Mussum Ipsum, cacilds vidis litro abertis. Todo mundo vê os porris que eu tomo, mas ninguém vê os tombis que eu levo! Sapien in monti palavris qui num significa nadis i pareci latim.  A ordem dos tratores não altera o pão duris. Quem manda na minha terra sou euzis! In elementis mé pra quem é amistosis quis leo. Quem num gosta di mé, boa gentis num é. Mais vale um bebadis conhecidiss, que um alcoolatra anonimis. Nullam volutpat risus nec leo commodo, ut interdum diam laoreet. Sed non consequat odio. Praesent malesuada urna nisi, quis volutpat erat hendrerit non. Nam vulputate dapibus. Manduma pindureta quium dia nois paga. Casamentiss faiz malandris se pirulitá. Per aumento de cachacis, eu reclamis. Mussum Ipsum, cacilds vidis litro abertis. Atirei o pau no gatis, per gatis num morreus. Diuretics paradis num copo é motivis de denguis. Suco de cevadiss deixa as pessoas mais interessantis. Quem manda na minha terra sou euzis!</p>

                    <div className="mx-auto" style={{ width: 250 }}>
                        <button className="mb-4 d-block btn btn-primary font-weight-bold border-0" onClick={{}} data-toggle="modal" data-target="#inputModalMentor" style={{ borderRadius: 20, backgroundColor: '#FF5B01', width: 250, height: 50, fontSize: 20 }}>Quero ser mentor</button>

                        <button className="mb-4 d-block btn btn-primary font-weight-bold border-0" onClick={{}} style={{ borderRadius: 20, backgroundColor: '#FF5B01', width: 250, height: 50, fontSize: 20 }}>Quero ser mentorado</button>

                        <div className="border-bottom max-auto" style={{ width: 250 }}>
                            <button className="border-0 font-weight-bold" style={{ backgroundColor: 'white', color: '#462842', fontSize: 20, width: 200 }}>Já tenho cadastro</button>
                        </div>
                    </div>


                </div>
            </div>
        );
    }
}

export default Welcome;