const { Seal } = require('node-seal');

async function compute(callback, streamParamString, streamSearchString, streamListString) {
    const Morfix = await Seal();

    const securityLevel = Morfix.SecurityLevel.tc128;

    //Load the variables from the memory stream
    const encParams = Morfix.EncryptionParameters();
    encParams.load(streamParamString);

    //Create the context and evaluator based on the parms
    const context = Morfix.Context(
        encParams, //Encryption Parameters
        true, //ExpandModChain
        securityLevel //Enforce a security level
    );
    const evaluator = Morfix.Evaluator(context);

    //Create the search Ciphertext
    const encryptedSearch = Morfix.CipherText();
    encryptedSearch.load(context, streamSearchString);

    //Create the data Ciphertext
    const encryptedData = Morfix.CipherText();
    encryptedData.load(context, streamListString);

    //Create the result Ciphertext and do the subtraction between the two ciphertexts
    const encryptedResult = Morfix.CipherText();
    evaluator.sub(encryptedData, encryptedSearch, encryptedResult);

    //Create the return memory stream and save the results to it
    const base64Results = encryptedResult.save();

    callback(/* error */ null, base64Results);
};

module.exports.compute = compute;
