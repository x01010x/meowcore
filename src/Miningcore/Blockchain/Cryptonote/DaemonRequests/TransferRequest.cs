using Newtonsoft.Json;

namespace Miningcore.Blockchain.Cryptonote.DaemonRequests;

public class TransferDestination
{
    public string Address { get; set; }
    public ulong Amount { get; set; }

    // Salvium
    /// <summary>
    /// Define the type of coin to be received
    /// </summary>
    [JsonProperty("asset_type", NullValueHandling = NullValueHandling.Ignore)]
    public string AssetType { get; set; }
}

public class TransferRequest
{
    public TransferDestination[] Destinations { get; set; }

    /// <summary>
    /// Number of outpouts from the blockchain to mix with (0 means no mixing)
    /// </summary>
    public uint Mixin { get; set; }

    /// <summary>
    /// Set a priority for the transaction. Accepted Values are: 0-3 for: default, unimportant, normal, elevated, priority
    /// </summary>
    public uint Priority { get; set; }

    /// <summary>
    /// Number of outputs to mix in the transaction (this output + N decoys from the blockchain)
    /// </summary>
    [JsonProperty("ring_size")]
    public uint RingSize { get; set; } = 16; //XEQ Error: Requested ring size 7 too low, using 16

    /// <summary>
    /// (Optional) Random 32-byte/64-character hex string to identify a transaction
    /// </summary>
    [JsonProperty("payment_id")]
    public string PaymentId { get; set; }

    /// <summary>
    /// (Optional) Return the transaction key after sending
    /// </summary>
    [JsonProperty("get_tx_key")]
    public bool GetTxKey { get; set; }

    /// <summary>
    /// (Optional) Return the transaction key after sending
    /// </summary>
    [JsonProperty("get_tx_hex")]
    public bool GetTxHex { get; set; }

    /// <summary>
    /// Number of blocks before the monero can be spent (0 to not add a lock)
    /// </summary>
    [JsonProperty("unlock_time")]
    public uint UnlockTime { get; set; }

    // Salvium
    /// <summary>
    /// Define the type of transaction
    /// </summary>
    [JsonProperty("tx_type", NullValueHandling = NullValueHandling.Ignore)]
    public uint? TransactionType { get; set; }
    // Salvium
    /// <summary>
    /// Define the type of coin to be sent
    /// </summary>
    [JsonProperty("source_asset", NullValueHandling = NullValueHandling.Ignore)]
    public string SourceAsset { get; set; }
    // Salvium
    /// <summary>
    /// Define the type of coin to be received
    /// </summary>
    [JsonProperty("dest_asset", NullValueHandling = NullValueHandling.Ignore)]
    public string DestinationAsset { get; set; }
}
